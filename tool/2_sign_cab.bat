::SignTool sign /f ..\..\..\tool\axframe.pfx /p axframe AxDemo.cab
::SignTool sign /f ..\..\..\tool\axframe.pfx /d "ActiveX Demo" /du "https://github.com/AmmRage/AxFrame" /p axframe AxDemo.cab
SignTool sign /f ..\..\..\tool\axframe.pfx /d "ActiveX Demo" /fd SHA256 /du "https://github.com/AmmRage/AxFrame"  /t http://timestamp.verisign.com/scripts/timstamp.dll /p axframe AxDemo.cab
pause