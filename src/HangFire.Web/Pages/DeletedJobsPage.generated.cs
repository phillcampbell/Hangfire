﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HangFire.Web.Pages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    #line 2 "..\..\Pages\DeletedJobsPage.cshtml"
    using Common;
    
    #line default
    #line hidden
    
    #line 4 "..\..\Pages\DeletedJobsPage.cshtml"
    using HangFire.Storage;
    
    #line default
    #line hidden
    
    #line 3 "..\..\Pages\DeletedJobsPage.cshtml"
    using Pages;
    
    #line default
    #line hidden
    
    #line 5 "..\..\Pages\DeletedJobsPage.cshtml"
    using States;
    
    #line default
    #line hidden
    
    #line 6 "..\..\Pages\DeletedJobsPage.cshtml"
    using Storage.Monitoring;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    internal partial class DeletedJobsPage : RazorPage
    {
#line hidden

        public override void Execute()
        {


WriteLiteral("\r\n");








            
            #line 8 "..\..\Pages\DeletedJobsPage.cshtml"
  
    Layout = new LayoutPage { Title = "Deleted Jobs" };

    int from, perPage;

    int.TryParse(Request.QueryString["from"], out from);
    int.TryParse(Request.QueryString["count"], out perPage);

    Pager pager;
    JobList<DeletedJobDto> jobs;

    using (var monitor = JobStorage.Current.GetMonitoringApi())
    {
        pager = new Pager(from, perPage, monitor.DeletedListCount())
        {
            BasePageUrl = Request.LinkTo("/deleted")
        };

        jobs = monitor.DeletedJobs(pager.FromRecord, pager.RecordsPerPage);
    }


            
            #line default
            #line hidden
WriteLiteral("\r\n");


            
            #line 30 "..\..\Pages\DeletedJobsPage.cshtml"
 if (pager.TotalPageCount == 0)
{

            
            #line default
            #line hidden
WriteLiteral("    <div class=\"alert alert-info\">\r\n        No deleted jobs found.\r\n    </div>\r\n");


            
            #line 35 "..\..\Pages\DeletedJobsPage.cshtml"
}
else
{

            
            #line default
            #line hidden
WriteLiteral("    <div class=\"js-jobs-list\">\r\n        <div class=\"btn-toolbar btn-toolbar-top\">" +
"\r\n            <button class=\"js-jobs-list-command btn btn-sm btn-primary\" \r\n    " +
"                data-url=\"");


            
            #line 41 "..\..\Pages\DeletedJobsPage.cshtml"
                         Write(Request.LinkTo("/deleted/requeue"));

            
            #line default
            #line hidden
WriteLiteral("\" \r\n                    data-loading-text=\"Enqueueing...\">\r\n                <span" +
" class=\"glyphicon glyphicon-repeat\"></span>\r\n                Requeue jobs\r\n     " +
"       </button>\r\n            ");


            
            #line 46 "..\..\Pages\DeletedJobsPage.cshtml"
       Write(RenderPartial(new PerPageSelector(pager)));

            
            #line default
            #line hidden
WriteLiteral(@"
        </div>
        <table class=""table table-hover"">
            <thead>
                <tr>
                    <th class=""min-width"">
                        <input type=""checkbox"" class=""js-jobs-list-select-all"" />
                    </th>
                    <th class=""min-width"">Id</th>
                    <th>Job</th>
                    <th>Deleted</th>
                </tr>
            </thead>
            <tbody>
");


            
            #line 60 "..\..\Pages\DeletedJobsPage.cshtml"
                 foreach (var job in jobs)
                {

            
            #line default
            #line hidden
WriteLiteral("                    <tr class=\"js-jobs-list-row ");


            
            #line 62 "..\..\Pages\DeletedJobsPage.cshtml"
                                            Write(job.Value != null && !job.Value.InDeletedState ? "obsolete-data" : null);

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                        <td>\r\n");


            
            #line 64 "..\..\Pages\DeletedJobsPage.cshtml"
                             if (job.Value.InDeletedState && job.Value != null)
                            {

            
            #line default
            #line hidden
WriteLiteral("                                <input type=\"checkbox\" class=\"js-jobs-list-checkb" +
"ox\" name=\"jobs[]\" value=\"");


            
            #line 66 "..\..\Pages\DeletedJobsPage.cshtml"
                                                                                                     Write(job.Key);

            
            #line default
            #line hidden
WriteLiteral("\" />\r\n");


            
            #line 67 "..\..\Pages\DeletedJobsPage.cshtml"
                            }

            
            #line default
            #line hidden
WriteLiteral("                        </td>\r\n                        <td>\r\n                    " +
"        <a href=\"");


            
            #line 70 "..\..\Pages\DeletedJobsPage.cshtml"
                                Write(Request.LinkTo("/job/" + job.Key));

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                                ");


            
            #line 71 "..\..\Pages\DeletedJobsPage.cshtml"
                           Write(HtmlHelper.JobId(job.Key));

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </a>\r\n");


            
            #line 73 "..\..\Pages\DeletedJobsPage.cshtml"
                             if (job.Value != null && !job.Value.InDeletedState)
                            {

            
            #line default
            #line hidden
WriteLiteral("                                <span title=\"Job\'s state has been changed while f" +
"etching data.\" class=\"glyphicon glyphicon-question-sign\"></span>\r\n");


            
            #line 76 "..\..\Pages\DeletedJobsPage.cshtml"
                            }

            
            #line default
            #line hidden
WriteLiteral("                        </td>\r\n\r\n");


            
            #line 79 "..\..\Pages\DeletedJobsPage.cshtml"
                         if (job.Value == null)
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <td colspan=\"3\">\r\n                                <em" +
">Job was expired.</em>\r\n                            </td>\r\n");


            
            #line 84 "..\..\Pages\DeletedJobsPage.cshtml"
                        }
                        else
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <td>\r\n                                <span title=\"");


            
            #line 88 "..\..\Pages\DeletedJobsPage.cshtml"
                                        Write(HtmlHelper.DisplayMethodHint(job.Value.Job));

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                                    ");


            
            #line 89 "..\..\Pages\DeletedJobsPage.cshtml"
                               Write(HtmlHelper.DisplayMethod(job.Value.Job));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                </span>\r\n                            </td>\r\n");



WriteLiteral("                            <td>\r\n");


            
            #line 93 "..\..\Pages\DeletedJobsPage.cshtml"
                                 if (job.Value.DeletedAt.HasValue)
                                {

            
            #line default
            #line hidden
WriteLiteral("                                    <span data-moment=\"");


            
            #line 95 "..\..\Pages\DeletedJobsPage.cshtml"
                                                  Write(JobHelper.ToStringTimestamp(job.Value.DeletedAt.Value));

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                                        ");


            
            #line 96 "..\..\Pages\DeletedJobsPage.cshtml"
                                   Write(job.Value.DeletedAt);

            
            #line default
            #line hidden
WriteLiteral("\r\n                                    </span>\r\n");


            
            #line 98 "..\..\Pages\DeletedJobsPage.cshtml"
                                }

            
            #line default
            #line hidden
WriteLiteral("                            </td>\r\n");


            
            #line 100 "..\..\Pages\DeletedJobsPage.cshtml"
                        }

            
            #line default
            #line hidden
WriteLiteral("                    </tr>\r\n");


            
            #line 102 "..\..\Pages\DeletedJobsPage.cshtml"
                }

            
            #line default
            #line hidden
WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n");


            
            #line 106 "..\..\Pages\DeletedJobsPage.cshtml"
    
            
            #line default
            #line hidden
            
            #line 106 "..\..\Pages\DeletedJobsPage.cshtml"
Write(RenderPartial(new Paginator(pager)));

            
            #line default
            #line hidden
            
            #line 106 "..\..\Pages\DeletedJobsPage.cshtml"
                                        
}

            
            #line default
            #line hidden

        }
    }
}
#pragma warning restore 1591