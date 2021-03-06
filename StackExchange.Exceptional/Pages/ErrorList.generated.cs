﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StackExchange.Exceptional.Pages
{
    using System;
    
    #line 2 "..\..\Pages\ErrorList.cshtml"
    using System.Collections.Generic;
    
    #line default
    #line hidden
    
    #line 3 "..\..\Pages\ErrorList.cshtml"
    using System.Linq;
    
    #line default
    #line hidden
    using System.Text;
    
    #line 4 "..\..\Pages\ErrorList.cshtml"
    using StackExchange.Exceptional;
    
    #line default
    #line hidden
    
    #line 6 "..\..\Pages\ErrorList.cshtml"
    using StackExchange.Exceptional.Extensions;
    
    #line default
    #line hidden
    
    #line 5 "..\..\Pages\ErrorList.cshtml"
    using StackExchange.Exceptional.Pages;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "1.4.1.0")]
    internal partial class ErrorList : RazorPageBase
    {
#line hidden

        #line 17 "..\..\Pages\ErrorList.cshtml"

    public string Url(string path)
    {
        return BasePageName.EndsWith("/") ? BasePageName + path : BasePageName + "/" + path;
    }

        #line default
        #line hidden

        public override void Execute()
        {


WriteLiteral("\r\n");








            
            #line 8 "..\..\Pages\ErrorList.cshtml"
  
    var log = ErrorStore.Default;
    var errors = new List<Error>();
    var total = log.GetAll(errors);
    errors = errors.OrderByDescending(e => e.CreationDate).ToList();
    
    Layout = new Master { PageTitle = "Error Log" };


            
            #line default
            #line hidden

WriteLiteral("\r\n");


            
            #line 23 "..\..\Pages\ErrorList.cshtml"
 if (log.InFailureMode)
{
    var le = ErrorStore.LastRetryException;

            
            #line default
            #line hidden
WriteLiteral("    <div class=\"failure-mode\">Error log is in failure mode, ");


            
            #line 26 "..\..\Pages\ErrorList.cshtml"
                                                       Write(ErrorStore.WriteQueue.Count);

            
            #line default
            #line hidden
WriteLiteral(" ");


            
            #line 26 "..\..\Pages\ErrorList.cshtml"
                                                                                     Write(ErrorStore.WriteQueue.Count == 1 ? "entry" : "entries");

            
            #line default
            #line hidden

            
            #line 26 "..\..\Pages\ErrorList.cshtml"
                                                                                                                                                  WriteLiteral(" queued to log.");

            
            #line default
            #line hidden
            
            #line 26 "..\..\Pages\ErrorList.cshtml"
                                                                                                                                                                  if(le != null){
            
            #line default
            #line hidden
WriteLiteral("<br />Last Logging Exception: ");


            
            #line 26 "..\..\Pages\ErrorList.cshtml"
                                                                                                                                                                                                                Write(le.Message);

            
            #line default
            #line hidden

            
            #line 26 "..\..\Pages\ErrorList.cshtml"
                                                                                                                                                                                                                                       }
            
            #line default
            #line hidden
WriteLiteral("</div>\r\n");



WriteLiteral("    <!-- Exception Details:\r\n");


            
            #line 28 "..\..\Pages\ErrorList.cshtml"
     if(ErrorStore.LastRetryException != null)
    {
        
            
            #line default
            #line hidden
            
            #line 30 "..\..\Pages\ErrorList.cshtml"
   Write(ErrorStore.LastRetryException.Message);

            
            #line default
            #line hidden
            
            #line 30 "..\..\Pages\ErrorList.cshtml"
                                              
        
            
            #line default
            #line hidden
            
            #line 31 "..\..\Pages\ErrorList.cshtml"
   Write(ErrorStore.LastRetryException.StackTrace);

            
            #line default
            #line hidden
            
            #line 31 "..\..\Pages\ErrorList.cshtml"
                                                 
    }

            
            #line default
            #line hidden
WriteLiteral("     -->\r\n");


            
            #line 34 "..\..\Pages\ErrorList.cshtml"
}

            
            #line default
            #line hidden

            
            #line 35 "..\..\Pages\ErrorList.cshtml"
 if (!errors.Any())
{

            
            #line default
            #line hidden
WriteLiteral("    <h1>No errors yet, yay!</h1>\r\n");


            
            #line 38 "..\..\Pages\ErrorList.cshtml"
}
else
{
    var last = errors.FirstOrDefault(); // oh the irony

            
            #line default
            #line hidden
WriteLiteral("<h1 id=\"errorcount\">");


            
            #line 42 "..\..\Pages\ErrorList.cshtml"
               Write(ErrorStore.ApplicationName);

            
            #line default
            #line hidden
WriteLiteral(" - ");


            
            #line 42 "..\..\Pages\ErrorList.cshtml"
                                             Write(total);

            
            #line default
            #line hidden
WriteLiteral(" Errors; last ");


            
            #line 42 "..\..\Pages\ErrorList.cshtml"
                                                                 Write(last.CreationDate.ToRelativeTime());

            
            #line default
            #line hidden
WriteLiteral("</h1>\r\n");



WriteLiteral(@"    <table id=""ErrorLog"" class=""alt-rows"">
        <thead>
            <tr>
                <th class=""type-col"">&nbsp;</th>
                <th class=""type-col"">Type</th>
                <th>Error</th>
                <th>Url</th>
                <th>Remote IP</th>
                <th>Time</th>
                <th>Site</th>
                <th>Server</th>
            </tr>
        </thead>
        <tbody>
");


            
            #line 57 "..\..\Pages\ErrorList.cshtml"
         foreach (var e in errors)
        {
            var fullUrl = "http://" + e.Host + e.Url;

            
            #line default
            #line hidden
WriteLiteral("            <tr data-id=\"");


            
            #line 60 "..\..\Pages\ErrorList.cshtml"
                    Write(e.GUID);

            
            #line default
            #line hidden
WriteLiteral("\" class=\"error");


            
            #line 60 "..\..\Pages\ErrorList.cshtml"
                                          Write(e.IsProtected ? " protected" : "");

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                <td>\r\n                    <a href=\"");


            
            #line 62 "..\..\Pages\ErrorList.cshtml"
                        Write(Url("delete"));

            
            #line default
            #line hidden
WriteLiteral("\" class=\"delete-link\" title=\"Delete this error\">&nbsp;X&nbsp;</a>\r\n");


            
            #line 63 "..\..\Pages\ErrorList.cshtml"
                     if (!e.IsProtected)
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <a href=\"");


            
            #line 65 "..\..\Pages\ErrorList.cshtml"
                            Write(Url("protect"));

            
            #line default
            #line hidden
WriteLiteral("\" class=\"protect-link\" title=\"Protect this error\">&nbsp;P&nbsp;</a>\r\n");


            
            #line 66 "..\..\Pages\ErrorList.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral("                </td>\r\n                <td class=\"type-col\" title=\"");


            
            #line 68 "..\..\Pages\ErrorList.cshtml"
                                       Write(e.Type);

            
            #line default
            #line hidden
WriteLiteral("\">");


            
            #line 68 "..\..\Pages\ErrorList.cshtml"
                                                Write(e.Type.ToShortException());

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                <td class=\"error-col\"><a href=\"");


            
            #line 69 "..\..\Pages\ErrorList.cshtml"
                                          Write(Url("info?guid="+@e.GUID));

            
            #line default
            #line hidden
WriteLiteral("\" class=\"info-link\">");


            
            #line 69 "..\..\Pages\ErrorList.cshtml"
                                                                                        Write(e.Message);

            
            #line default
            #line hidden
WriteLiteral("</a> \r\n");


            
            #line 70 "..\..\Pages\ErrorList.cshtml"
                     if(e.DuplicateCount > 1)
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <span class=\"duplicate-count\" title=\"number of similar er" +
"rors occurring close to this error\">(");


            
            #line 72 "..\..\Pages\ErrorList.cshtml"
                                                                                                                 Write(e.DuplicateCount);

            
            #line default
            #line hidden
WriteLiteral(")</span>\r\n");


            
            #line 73 "..\..\Pages\ErrorList.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral("                </td>\r\n                <td>\r\n");


            
            #line 76 "..\..\Pages\ErrorList.cshtml"
                     if (e.HTTPMethod == "GET" && e.Url.HasValue())
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <a href=\"");


            
            #line 78 "..\..\Pages\ErrorList.cshtml"
                            Write(fullUrl);

            
            #line default
            #line hidden
WriteLiteral("\" title=\"");


            
            #line 78 "..\..\Pages\ErrorList.cshtml"
                                             Write(fullUrl);

            
            #line default
            #line hidden
WriteLiteral("\" class=\"url-link\">");


            
            #line 78 "..\..\Pages\ErrorList.cshtml"
                                                                        Write(e.Url.TruncateWithEllipsis(40));

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n");


            
            #line 79 "..\..\Pages\ErrorList.cshtml"
                    }
                    else if (e.Url.HasValue())
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <span title=\"");


            
            #line 82 "..\..\Pages\ErrorList.cshtml"
                                Write(fullUrl);

            
            #line default
            #line hidden
WriteLiteral("\">");


            
            #line 82 "..\..\Pages\ErrorList.cshtml"
                                          Write(e.Url.TruncateWithEllipsis(40));

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n");


            
            #line 83 "..\..\Pages\ErrorList.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral("                </td>\r\n                <td>");


            
            #line 85 "..\..\Pages\ErrorList.cshtml"
               Write(e.IPAddress);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                <td><span title=\"");


            
            #line 86 "..\..\Pages\ErrorList.cshtml"
                             Write(string.Format("{0:G} -- {1:u}", e.CreationDate, e.CreationDate.ToUniversalTime()));

            
            #line default
            #line hidden
WriteLiteral("\">");


            
            #line 86 "..\..\Pages\ErrorList.cshtml"
                                                                                                                  Write(e.CreationDate.ToRelativeTime());

            
            #line default
            #line hidden
WriteLiteral("</span></td>\r\n                <td>");


            
            #line 87 "..\..\Pages\ErrorList.cshtml"
               Write(e.Host);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                <td>");


            
            #line 88 "..\..\Pages\ErrorList.cshtml"
               Write(e.MachineName);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n            </tr>\r\n");


            
            #line 90 "..\..\Pages\ErrorList.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("        </tbody>\r\n    </table>\r\n");


            
            #line 93 "..\..\Pages\ErrorList.cshtml"
    if (errors.Any(e => !e.IsProtected))
    {

            
            #line default
            #line hidden
WriteLiteral("    <div class=\"clear-all-div\">\r\n        <a class=\"delete-link clear-all-link\" hr" +
"ef=\"");


            
            #line 96 "..\..\Pages\ErrorList.cshtml"
                                               Write(Url("delete-all"));

            
            #line default
            #line hidden
WriteLiteral("\">&nbsp;X&nbsp;- Clear all non-protected errors</a>\r\n    </div>\r\n");


            
            #line 98 "..\..\Pages\ErrorList.cshtml"
    }
}
            
            #line default
            #line hidden

        }
    }
}
#pragma warning restore 1591
