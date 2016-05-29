# 0 - 60 with Angular 2 & Visual Studio

This is a presentation I first gave at the AngularMN meetup on June 2, 2016. The talk is meant to provide a walk through the experience creating an API and Angular 2 application when using Visual Studio 2015 as your primary editor.

## The talk itself

TODO - I will post a link here once the talk is complete.

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

That will get you at step 4 of the code and you can experiement from there.

## Related blog posts

I also wrote up a couple of blog posts that go into some more detail about my experiences using Visual Studio for API and Angular 2 development. Here are the links to those:

- [0 - 60 with Angular 2 & Visual Studio - Part 1](https://blog.sstorie.com/0-60-with-angular-2-and-visual-studio-part-1/)
- [0 - 60 with Angular 2 & Visual Studio - Part 2](https://blog.sstorie.com/0-60-with-angular-2-and-visual-studio-part-2/)

## Have any comments or feedback?

Please let me know if you have any questions, comments or general feedback on the talk, the code, or the blog posts. I'm always excited to get feedback, so please don't hesitate to reach out.
