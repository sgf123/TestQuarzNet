# .NETFramework 4.6.2  

## 说明
本项目仅作为参考项目，帮助大家能够快速使用QuarzNet和Topshelf进行系统服务开发部署，可视化系统服务管理

## NuGet
*  Quartz（3.0.6）
*  Topshelf（4.0.4）
*  log4net（2.0.0）
*  Quartz.Plugins（3.0.6）

## 框架结构
``` 
TestQuarzNet
	├── TestQuarzNet.Service（服务层）
	├── TestQuarzNetFramework （控制台程序）
	├── TestQuarzNetWeb (可视化网站站点)
	├── TestQuarzNetWin（系统服务） 
  
```

## 使用帮助
配置文件说明：
1.quartz.config
2.quartz_job.xls
3.log4net.config
 
可视化服务管理站点：
localhost:xxx/CrystalQuartzPanel.axd

#可视化管理站点需保证配置Tcp端口和服务安装的Tcp端口相同
 
