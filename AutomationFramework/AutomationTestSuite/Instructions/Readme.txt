Browser: Internet Explorer 11

Goto > Internet Options > Security Tab.

Security Tab
	- Enable Protected Mode (For all zones)

Goto > Advanced Tab

Advanced Tab
	- Enable 64 bit processes for enhanced protected mode *-ON (Send Key Issue)


Browser: Mozilla Firefox
	- Install the version placed under installer directory (ver. <= 46.0.1).
	- Open firefox and type about:config in URL.
	- In config page, use filter field to find "network.automatic-ntlm-auth.trusted-uris" configuration parameter. Double-click the name of the configuration parameter and enter the URLs of the sites you wish to enable NTLM authentication. 
	- Add the URL appearing on the authentication popup the restart the browser.

Browser: Google Chrome
	- Install the version placed under installer directory (ver. 51.0.2704.103, 52.0.2743.60) from installer folder.
	- Disable chrome auto update. Goto -> services.msc and disable the google update service.
	- By Pass NTLM authentication popup. Open IE -> Goto Internet options-> Security Tab -> Local Intranet. Click sites button -> Advanced then add site (e.g.: https://*.partners.extranet.microsoft.com/AgreementWeb/Login.aspx)
Refrences:
http://www.vcskicks.com/selenium-extensions.php
https://www.softexia.com/windows/web-browsers/google-chrome