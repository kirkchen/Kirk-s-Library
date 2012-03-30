using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Button 擴充功能
/// </summary>
public static class ButtonExtensions
{
    /// <summary>
    /// Prevents the double click.
    /// </summary>
    /// <param name="button">The button.</param>
	public static void PreventDoubleClick(this Button button)
    {
        var script = @"if(typeof(Page_ClientValidate) == 'function')
                       {
                           if(Page_ClientValidate())
                           {
                               this.disabled = true;                                                               
                           }
                           else
                           { 
                               return false;
                           }
                       }
                       else
                       {
                           this.disabled = true;                                                           
                       }";
       
        script = script.Replace(Environment.NewLine, string.Empty);       

        button.UseSubmitBehavior = false;
        button.OnClientClick = script;
    }
}