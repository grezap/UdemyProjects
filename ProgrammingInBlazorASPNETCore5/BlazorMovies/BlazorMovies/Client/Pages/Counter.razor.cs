using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMovies.Client.Pages
{
    public partial class Counter
    {
        [Inject] IJSRuntime js { get; set; }

        private int currentCount = 0;
        private static int currentCountStatic = 0;
        //Javascript Isolation, download the javascript Counter.js only when IncrementCount method from Counter componenet is called
        IJSObjectReference module;


        [JSInvokable]
        public async Task IncrementCount()
        {
            module = await js.InvokeAsync<IJSObjectReference>("import", "./js/Counter.js");
            await module.InvokeVoidAsync("displayAlert","Hello World");
            currentCount++;
            currentCountStatic++;
            await js.InvokeVoidAsync("dotNetStaticInvocation");
        }

        private async Task IncrementCountJavascript()
        {
            await js.InvokeVoidAsync("dotNetInstanceInvocation",DotNetObjectReference.Create(this));
        }

        [JSInvokable]
        public static Task<int> GetCurrentCount()
        {
            return Task.FromResult(currentCountStatic);
        }

    }
}
