Hangfire 
=========

#### [Official Site](http://hangfire.io) | [Blog](http://odinserj.net) | [Documentation](http://docs.hangfire.io) | [Forum](http://discuss.hangfire.io) | [Twitter](https://twitter.com/hangfire_net) | [NuGet Packages](https://www.nuget.org/packages?q=hangfire)

| Windows / .NET | Linux / Mono
| --- | ---
| <a href="https://ci.appveyor.com/project/odinserj/hangfire-525"><img title="Build status" width="113" src="https://ci.appveyor.com/api/projects/status/70m632jkycqpnsp9/branch/master?retina=true" /></a> | <a href="https://travis-ci.org/HangfireIO/Hangfire"><img src="https://travis-ci.org/HangfireIO/Hangfire.svg?branch=master" alt="Travis CI Build"></a>

Incredibly easy way to perform **fire-and-forget**, **delayed** and **recurring jobs** inside **ASP.NET applications**. CPU and I/O intensive, long-running and short-running jobs are supported. No Windows Service / Task Scheduler required. Backed by Redis, SQL Server, SQL Azure or MSMQ.

Hangfire provides unified programming model to handle background tasks in a **reliable way** and run them on shared hosting, dedicated hosting or in cloud. You can start with a simple setup and grow computational power for background jobs with time for these scenarios:

- mass notifications/newsletter;
- batch import from xml, csv, json;
- creation of archives;
- firing off web hooks;
- deleting users;
- building different graphs;
- image/video processing;
- purge temporary files;
- recurring automated reports;
- database maintenance;
- *…and so on.*

Hangfire is a .NET Framework alternative to [Resque](https://github.com/resque/resque), [Sidekiq](http://sidekiq.org), [delayed_job](https://github.com/collectiveidea/delayed_job).

![Hangfire Succeeded Job](http://hangfire.io/img/succeeded-job-sm.png)

Installation
-------------

Hangfire is available as a NuGet package. So, install it using the NuGet Package Console window:

```
PM> Install-Package Hangfire
```

After install, update your existing [OWIN Startup](http://www.asp.net/aspnet/overview/owin-and-katana/owin-startup-class-detection) file with the following lines of code. If you do not have this class in your project or don't know what is it, please read the [Quick start](http://docs.hangfire.io/en/latest/quickstart.html) guide to learn about how to install Hangfire.

```csharp
app.UseHangfire(config =>
{
    config.UseSqlServerStorage("<connection string or its name>");
    config.UseServer();
});
```

Usage
------

This is incomplete list of features, to see all of them, check the [official site](http://hangfire.io) and the [documentation](http://docs.hangfire.io).

[**Fire-and-forget tasks**](http://docs.hangfire.io/en/latest/users-guide/background-methods/calling-methods-in-background.html)

Enqueued background jobs are being executed inside a dedicated worker pool threads as soon as possible, shortening your request processing time.

```csharp
BackgroundJob.Enqueue(() => Console.WriteLine("Simple!"));
```

[**Delayed tasks**](http://docs.hangfire.io/en/latest/users-guide/background-methods/calling-methods-with-delay.html)

Scheduled background jobs are being executed only after given amount of time.

```csharp
BackgroundJob.Schedule(() => Console.WriteLine("Reliable!"), TimeSpan.FromDays(7));
```

[**Recurring tasks**](http://docs.hangfire.io/en/latest/users-guide/background-methods/performing-recurrent-tasks.html)

Recurring jobs were never been simpler, just call the following method to perform any kind of recurring task using the [CRON expressions](http://en.wikipedia.org/wiki/Cron#CRON_expression).

```csharp
RecurringJob.AddOrUpdate(() => Console.WriteLine("Transparent!"), Cron.Daily);
```

**Process them inside a web application…**

You can process background tasks in any OWIN compatible application frameworks, including [ASP.NET MVC](http://www.asp.net/mvc), [ASP.NET Web API](http://www.asp.net/web-api), [FubuMvc](http://fubu-project.org), [Nancy](http://nancyfx.org), etc. Forget about [AppDomain unloads, Web Garden & Web Farm issues](http://haacked.com/archive/2011/10/16/the-dangers-of-implementing-recurring-background-tasks-in-asp-net.aspx/) – Hangfire is reliable for web applications from scratch, even on shared hosting.

```csharp
app.UseHangfire(config => config.UseServer());
```

**… or anywhere else**

In console application, Windows Service, Azure Worker Role, etc.

```csharp
var server = new BackgroundJobServer();
server.Start();
```

Questions? Problems?
---------------------

Open-source project are developing more smoothly, when all discussions are held in public.

If you have any questions, problems related to the Hangfire usage or want to discuss new features, please visit the [discussion forum](http://discuss.hangfire.io). You can sign in there using your existing Google or GitHub account, so it's very simple to start using it.

If you've discovered a bug, please report it to the [Hangfire GitHub Issues](https://github.com/odinserj/Hangfire/issues?state=open). Detailed reports with stack traces, actual and expected behavours are welcome. 

Related Projects
-----------------

* [Hangfire.Dashboard.Authorization](https://github.com/HangfireIO/Hangfire.Dashboard.Authorization)
* [Hangfire.Autofac](https://github.com/HangfireIO/Hangfire.Autofac)
* [Hangfire.Ninject](https://github.com/HangfireIO/Hangfire.Ninject)
* [Hangfire.SimpleInjector](https://github.com/devmondo/Hangfire.SimpleInjector) by [@devmondo](https://github.com/devmondo)
* [Hangfire.Windsor](https://github.com/BredStik/Hangfire.Windsor) by [@BredStik](https://github.com/BredStik)
* [Hangfire.Azure.QueueStorage](https://github.com/HangfireIO/Hangfire.Azure.QueueStorage)
* [Hangfire.Azure.ServiceBusQueue](https://github.com/HangfireIO/Hangfire.Azure.ServiceBusQueue)

Roadmap
--------

* Full documentation for product and its API.
* More tutorials and articles that describe the features and use cases.
* ~~Recurring jobs support to fully cover all background needs.~~
* Support for other job storages, ~~including Microsoft Azure Storage~~.
* Make it easier to maintain jobs, even on large-scale systems.
* Deliver the solution to the 90% of ASP.NET developers :smile:.

License
--------

Copyright © 2013-2014 Sergey Odinokov.

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Lesser General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Lesser General Public License for more details.

You should have received a copy of the GNU Lesser General Public License
along with this program.  If not, see [http://www.gnu.org/licenses/](http://www.gnu.org/licenses).
