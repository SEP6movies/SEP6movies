#pragma checksum "/Users/ioanagrigore/RiderProjects/SEP6movies/SEP6-movies/Shared/NavMenu.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1609f9e42e0ed4d841b1a323527683d40ebbd064"
// <auto-generated/>
#pragma warning disable 1591
namespace test_shit.Shared
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "/Users/ioanagrigore/RiderProjects/SEP6movies/SEP6-movies/_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/ioanagrigore/RiderProjects/SEP6movies/SEP6-movies/_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/Users/ioanagrigore/RiderProjects/SEP6movies/SEP6-movies/_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/Users/ioanagrigore/RiderProjects/SEP6movies/SEP6-movies/_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "/Users/ioanagrigore/RiderProjects/SEP6movies/SEP6-movies/_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "/Users/ioanagrigore/RiderProjects/SEP6movies/SEP6-movies/_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "/Users/ioanagrigore/RiderProjects/SEP6movies/SEP6-movies/_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "/Users/ioanagrigore/RiderProjects/SEP6movies/SEP6-movies/_Imports.razor"
using test_shit;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "/Users/ioanagrigore/RiderProjects/SEP6movies/SEP6-movies/_Imports.razor"
using test_shit.Shared;

#line default
#line hidden
#nullable disable
    public partial class NavMenu : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "nav");
            __builder.AddAttribute(1, "class", "navbar navbar-expand-sm navbar-toggleable-sm navbar-light bg-white border-bottom box-shadow mb-3");
            __builder.AddMarkupContent(2, "\n    ");
            __builder.OpenElement(3, "div");
            __builder.AddAttribute(4, "class", "container");
            __builder.AddMarkupContent(5, "\n        ");
            __builder.AddMarkupContent(6, "<a class=\"navbar-brand\" href><img class=\"logoIcon\" src=\"icons/icons8-movie-64.png\"></a>\n        ");
            __builder.OpenElement(7, "button");
            __builder.AddAttribute(8, "class", "navbar-toggler");
            __builder.AddAttribute(9, "type", "button");
            __builder.AddAttribute(10, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 5 "/Users/ioanagrigore/RiderProjects/SEP6movies/SEP6-movies/Shared/NavMenu.razor"
                                                               ToggleNavMenu

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(11, "\n            <span class=\"navbar-toggler-icon\"></span>\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(12, "\n        ");
            __builder.OpenElement(13, "div");
            __builder.AddAttribute(14, "class", 
#nullable restore
#line 8 "/Users/ioanagrigore/RiderProjects/SEP6movies/SEP6-movies/Shared/NavMenu.razor"
                     NavMenuCssClass

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(15, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 8 "/Users/ioanagrigore/RiderProjects/SEP6movies/SEP6-movies/Shared/NavMenu.razor"
                                                ToggleNavMenu

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(16, "\n             ");
            __builder.AddMarkupContent(17, @"<ul class=""navbar-nav"">
                 <li class=""nav-item flex-grow-1"">
                     <form id=""form""> 
                         <input type=""search"" id=""query"" name=""q"" placeholder=""Search..."">
                         <button>Search</button>
                     </form>
                 </li>
                 <li class=""nav-item flex-grow-1"">
                     <img class=""advancedSearchIcon"" src=""icons/icons8-plus-+-64.png"">
                 </li>
                 <div class=""dropdown"">
                   <div class=""btn btn-secondary dropdown-toggle"" type=""button"" id=""dropdownMenuButton"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
                     <img class=""profileIcon"" alt=""user"" src=""icons/icons8-male-user-64.png"">
                   </div>
                   <div class=""dropdown-menu"" aria-labelledby=""dropdownMenuButton"">
                     <a class=""dropdown-item"" href=""#"">Action</a>
                     <a class=""dropdown-item"" href=""#"">Another action</a>
                     <a class=""dropdown-item"" href=""#"">Something else here</a>
                   </div>
                 </div>
             </ul>
            ");
            __builder.OpenElement(18, "ul");
            __builder.AddAttribute(19, "class", "navbar-nav flex-grow-1");
            __builder.AddMarkupContent(20, "\n                ");
            __builder.OpenElement(21, "li");
            __builder.AddAttribute(22, "class", "nav-item");
            __builder.AddMarkupContent(23, "\n                    ");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Routing.NavLink>(24);
            __builder.AddAttribute(25, "class", "nav-link text-dark");
            __builder.AddAttribute(26, "href", "");
            __builder.AddAttribute(27, "Match", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.Routing.NavLinkMatch>(
#nullable restore
#line 32 "/Users/ioanagrigore/RiderProjects/SEP6movies/SEP6-movies/Shared/NavMenu.razor"
                                                                       NavLinkMatch.All

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(28, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(29, "\n                        <span aria-hidden=\"true\"></span> ");
                __builder2.AddMarkupContent(30, "<h5 class=\"navigation\">Movies</h5>\n                    ");
            }
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(31, "\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(32, "\n                ");
            __builder.OpenElement(33, "li");
            __builder.AddAttribute(34, "class", "nav-item");
            __builder.AddMarkupContent(35, "\n                    ");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Routing.NavLink>(36);
            __builder.AddAttribute(37, "class", "nav-link text-dark");
            __builder.AddAttribute(38, "href", "Actors");
            __builder.AddAttribute(39, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(40, "\n                        <span aria-hidden=\"true\"></span> ");
                __builder2.AddMarkupContent(41, "<h5 class=\"navigation\">Actors</h5>\n                    ");
            }
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(42, "\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(43, "\n                ");
            __builder.OpenElement(44, "li");
            __builder.AddAttribute(45, "class", "nav-item");
            __builder.AddMarkupContent(46, "\n                    ");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Routing.NavLink>(47);
            __builder.AddAttribute(48, "class", "nav-link text-dark");
            __builder.AddAttribute(49, "href", "Directors");
            __builder.AddAttribute(50, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(51, "\n                        <span aria-hidden=\"true\"></span> ");
                __builder2.AddMarkupContent(52, "<h5 class=\"navigation\">Directors</h5>\n                    ");
            }
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(53, "\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(54, "\n\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(55, "\n\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(56, "\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(57, "\n");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 54 "/Users/ioanagrigore/RiderProjects/SEP6movies/SEP6-movies/Shared/NavMenu.razor"
       
    bool collapseNavMenu = true;

    string baseMenuClass = "navbar-collapse d-sm-inline-flex flex-sm-row-reverse";

    string NavMenuCssClass => baseMenuClass + (collapseNavMenu ? " collapse" : "");

    void ToggleNavMenu()
    {
        collapseNavMenu = !collapseNavMenu;
    }

   


#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
