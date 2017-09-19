try {	
	#PowerShell -ExecutionPolicy Bypass -File "\\Co1bpdcsvctfs07.redmond.corp.microsoft.com\e$\Deploy\Task.Powershell.Cleanup\Cleanup.Process.ps1"
	#Set-ExecutionPolicy Bypass "Cleanup.Process.ps1"
	#Unblock-File "\\Co1bpdcsvctfs07.redmond.corp.microsoft.com\e$\Deploy\Task.Powershell.Cleanup\Cleanup.Process.ps1"
	Stop-Process -processname "Chrome*" 
	Stop-Process -processname "IEDriver*"
    Stop-Process -processname "iexplore*"
	Stop-Process -processname "PhantomJS*"
	#Stop-Process -processname "Internet Explorer" 
} catch {

} finally {
	
}
