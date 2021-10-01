function myFunction(message) {
    console.log("From Utilities " + message);
}

function dotNetStaticInvocation() {
    DotNet.invokeMethodAsync("BlazorMovies.Client", "GetCurrentCount")
        .then(result => {
            console.log("count from javascript " +result);
        })
}

function dotNetInstanceInvocation(dotNetHelper) {
    dotNetHelper.invokeMethodAsync("IncrementCount"); //this also returns a promise
}