# 0 - 60 with Angular 2 & Visual Studio

This is a presentation I first gave at the AngularMN meetup on June 2, 2016. The talk is meant to provide a walk through the experience creating an API and Angular 2 application when using Visual Studio 2015 as your primary editor.

## The talk itself

TODO - I will post a link here once the talk is complete.

## The slides

This is not a slide heavy talk, so there isn't much available, but the few slides I do have are [available here](slides) or via [Google Docs](https://docs.google.com/presentation/d/1HSwWHnjqRyLL9h5MfhrFqFVKwmhh3zbJIJMApKtv_-4/pub?start=false&loop=false&delayms=3000).

## Explanation of this repository

This repository contains the presentation and the source code for the example I use during the talk. This repo has been tagged with multiple steps to make it easy to walk through the progress yourself. Here's an outline of the available tags:

- [Step 1](https://github.com/sstorie/presentation-0-60-with-angular2-and-visual-studio/tree/step-1) - An empty ASP.NET 4.5 project with all required NuGet packages already added
- [Step 2](https://github.com/sstorie/presentation-0-60-with-angular2-and-visual-studio/tree/step-2) - A basic API scaffold with Swagger enabled (via the Swashbuckle library)
- [Step 3](https://github.com/sstorie/presentation-0-60-with-angular2-and-visual-studio/tree/step-3) - The fully complete API with Swagger updated to include XML comments
- [Step 4](https://github.com/sstorie/presentation-0-60-with-angular2-and-visual-studio/tree/step-4) - Nancy added to provide the context needed to serve our Angular 2 application
- [Step 5](https://github.com/sstorie/presentation-0-60-with-angular2-and-visual-studio/tree/step-5) - The full Angular app (with all required configuration files) but without any error handling in the UI
- [Step 6](https://github.com/sstorie/presentation-0-60-with-angular2-and-visual-studio/tree/step-6) - The final Angular app with all error handling added

To checkout the code at a given step simply clone the repo and run a command like the following:

`git checkout tags/step-4 -f`

That will get you to step 4 of the code and you can experiment from there.

## Related blog posts & resources

I also wrote up a couple of blog posts that go into some more detail about my experiences using Visual Studio for API and Angular 2 development. Here are the links to those:

- [0 - 60 with Angular 2 & Visual Studio - Part 1](https://blog.sstorie.com/0-60-with-angular-2-and-visual-studio-part-1/)
- [0 - 60 with Angular 2 & Visual Studio - Part 2](https://blog.sstorie.com/0-60-with-angular-2-and-visual-studio-part-2/)

Since we're working with Visual Studio in this talk there are also a couple nice extensions that might help improve your experience. Here's links to a few that you might be interested in:

- [NPM Task Runner extension](https://visualstudiogallery.msdn.microsoft.com/8f2f2cbc-4da5-43ba-9de2-c9d08ade4941) (free)
- [Web Essentials 2015](https://visualstudiogallery.msdn.microsoft.com/ee6e6d8c-c837-41fb-886a-6b50ae2d06a2) (free)
- [Productivity Power Tools](https://visualstudiogallery.msdn.microsoft.com/34ebc6a2-2777-421d-8914-e29c1dfa7f5d) (free)
- [ReSharper](https://www.jetbrains.com/resharper/) (not free) - Love it or hate it...I find it useful and worth paying for.

## Have any comments or feedback?

Please let me know if you have any questions, comments or general feedback on the talk, the code, or the blog posts. I'm always excited to get feedback, so please don't hesitate to reach out.
