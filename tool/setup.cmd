::@echo off
::%windir% is C:\WINDOWS
::C:\WINDOWS\system32\AxDemo.dll

set AxDemo=%windir%\SysWoW64\AxDemo.dll
copy AxDemo.dll %AxDemo%
RegNetX install %AxDemo%