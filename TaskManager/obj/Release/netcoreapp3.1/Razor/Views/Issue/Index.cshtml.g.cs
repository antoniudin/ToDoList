#pragma checksum "C:\Users\Uismolvb\source\repos\TaskManager\TaskManager\Views\Issue\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ec584fc80b833d88a17792b30d1c1dcd1c32daf7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Issue_Index), @"mvc.1.0.view", @"/Views/Issue/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Uismolvb\source\repos\TaskManager\TaskManager\Views\_ViewImports.cshtml"
using TaskManager;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Uismolvb\source\repos\TaskManager\TaskManager\Views\_ViewImports.cshtml"
using TaskManager.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\Uismolvb\source\repos\TaskManager\TaskManager\Views\Issue\Index.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ec584fc80b833d88a17792b30d1c1dcd1c32daf7", @"/Views/Issue/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cc035caf78427af9c0e6c60ac75693646a0d7e84", @"/Views/_ViewImports.cshtml")]
    public class Views_Issue_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TaskManager.Models.ApplicationViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\Uismolvb\source\repos\TaskManager\TaskManager\Views\Issue\Index.cshtml"
  
    ViewBag.Title = "Issues";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h4>Tasks</h4>\r\n\r\n<div class=\"form-outline\">\r\n    <input type=\"search\" id=\"form1\" class=\"form-control\" placeholder=\"Search\" aria-label=\"Search\" />\r\n</div>\r\n<div class=\"space\"></div>\r\n\r\n<div class=\"panel\">\r\n    <div>\r\n        ");
#nullable restore
#line 18 "C:\Users\Uismolvb\source\repos\TaskManager\TaskManager\Views\Issue\Index.cshtml"
   Write(Html.ActionLink("New Task", "New", "Issue", null, new { @class = "btn btn-sm btn-primary panel" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    </div>
    <div class=""space""></div>
    <div class=""form-check panel"">
        <input class=""form-check-input align-middle"" type=""checkbox"" id=""checkbox"" name=""hidetasks"" value=""True"">
        <br />
        <label class=""form-check-label align-middle"" for=""hidetasks"">Hide completed tasks</label>
    </div>
</div>
<div class=""space""></div>

<table id=""Issues"" class=""table"" data-paging=""false"" data-ordering=""true""></table>

");
            DefineSection("scripts", async() => {
                WriteLiteral(@"
        
    <script>
        $(document).ready(function () {

    //building a table
    var tbl = $(""#Issues"").DataTable({
            ajax: {
            url: ""/api/Issues/"",
            dataSrc: """"
        },

        columns: [
            {
            title: ""Title"",
                data: ""name"",
                render: function (data, type, issue) {
                    if (issue.isDone == false) {
                        var result = ""<a href='issue/edit/"" + issue.id + ""'>"" + issue.name + ""</a>"";
                    }
                    else {
            result = data;
                    }
                    return result;
                }
            },
            {
            title: ""Creation Date"",
                data: ""creationDate"",
                render: function (data) {
                    var date = new Date(data);
                    var month = date.getMonth() + 1;
                    var day = date.getDate();
                    var m = month.toSt");
                WriteLiteral(@"ring().length > 1 ? month : ""0"" + month;
                    var d = day.toString().length > 1 ? day : ""0"" + day;
                    var result = m + ""/"" + d + ""/"" + date.getFullYear();
                    return ""<p>"" + result + ""</p>"";
                }
            },

            {
            title: ""Deadline"",
                data: ""dueDate"",
                render: function (data) {
                    var date = new Date(data);
                    var month = date.getMonth() + 1;
                    var day = date.getDate();
                    var m = month.toString().length > 1 ? month : ""0"" + month;
                    var d = day.toString().length > 1 ? day : ""0"" + day;
                    var result = m + ""/"" + d + ""/"" + date.getFullYear();
                    return ""<p>"" + result + ""</p>"";
                }
            },

            {
            title: ""Type"",
                data: ""issueType.name""
            },

            {
            title: ""Status"",
       ");
                WriteLiteral(@"         data: ""issueStatus.name""
            },

            {
            title: ""User"",
                data: ""creationUser""
            },

            {
            title: ""Done"",
                data: ""isDone""
            },

            {
            data: ""id"",
                render: function (data, type, issue) {
                    if (issue.isDone == false) {
                        var result = ""<a class='btn btn-sm btn-primary js-complete' href='/issue/complete/"" + data + ""'>Complete</a> <button class='btn btn-sm btn-primary js-delete' data-issue-id="" + data + "">Delete</button> <a class='btn btn-sm btn-primary' href='/issue/edit/"" + data + ""'>Edit</a>"";
                    }

                    else {
                        var result = ""<a class='btn btn-sm btn-primary js-complete' href='/issue/complete/"" + data + ""'>Activate</a> <div class='btn btn-sm btn-secondary'>Delete</div> <div class='btn btn-sm btn-secondary' href=''>Edit</div>"";
                    }
          ");
                WriteLiteral("          return result;\r\n                }\r\n            }\r\n        ],\r\n        createdRow: function (row) {\r\n            $(row).attr(\'redline\');\r\n        }\r\n    });\r\n\r\n    //filtering tables by User\r\n    tbl.columns(5).search(\'");
#nullable restore
#line 125 "C:\Users\Uismolvb\source\repos\TaskManager\TaskManager\Views\Issue\Index.cshtml"
                      Write(User.Identity.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"', true, false).draw();

    //hiding completed tasks
    $(""#checkbox"").on(""change"", function () {
        var flag = document.getElementById(""checkbox"");
        if (flag.checked == true) {
            tbl.columns(6).search('false', true, false).draw();
        } else {
            tbl.columns(6).search('').draw();
        }
    });

    //hidding user column
    tbl.column(5).visible(false);
    tbl.column(6).visible(false);

    //setting custom search
    $('#form1').on('keyup', function () {
            tbl.search($(this).val()).draw();
    });

    //bootbox delete function
    $(""#Issues"").on(""click"", "".js-delete"", function () {
        var button = $(this);
        bootbox.confirm({
            message: ""Do you want to delete this Task?"",
            buttons: {
            confirm: {
            label: 'Yes',
                    className: 'btn-secondary'
                },
                cancel: {
            label: 'No',
                    className: 'btn-primary'");
                WriteLiteral(@"
                }
            },
            callback: function (result) {
                if (result) {
            $.ajax({
                url: ""/api/Issues/"" + button.attr(""data-Issue-id""),
                method: ""DELETE"",
                success: function () {
                    tbl.row(button.parents(""tr"")).remove().draw();
                }
            });
                }
            }
        });

    });
});

</script>

");
            }
            );
            WriteLiteral("\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TaskManager.Models.ApplicationViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
