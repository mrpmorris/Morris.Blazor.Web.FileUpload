using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morris.Blazor.Web.FileUpload;

internal readonly record struct FileUploadInfo(string HtmlInputId, int HtmlInputFileIndex, IBrowserFile BrowserFile);
