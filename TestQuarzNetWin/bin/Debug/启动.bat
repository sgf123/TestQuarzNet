@echo.服务启动......  
@echo off  
@sc create QuarzNetSvr binPath= "E:\git\QuarzNet\TestQuarzNet\TestQuarzNetWin\bin\Debug\TestQuarzNetWin.exe"  
@net start QuarzNetSvr  
@sc config QuarzNetSvr start= AUTO  
@echo off  
@echo.启动完毕！  
@pause