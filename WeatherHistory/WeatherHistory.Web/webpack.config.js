// An attempt at a very simple webpack config file that shows
//  the minimum required to "compile" an angular app using
//  Sass (with view encapsulation), and external HTML templates
//
var autoprefixer = require("autoprefixer");

module.exports = {
    // Define the entry points for our application so webpack knows what to 
    //  use as inputs
    //
    entry: {
        app: ["./App/main"]
    },

    // Define where the resulting file should go
    //
    output: {
        filename: "content/[name].bundle.js"
    },

    // Define the extensions that we want webpack to resolve (we need to 
    //  override the default to ensure .ts files are included)
    //
    resolve: {
        extensions: ["", ".ts", ".js"]
    },

    // Turn on source maps for all applicable files.
    //
    devtool: "source-map",

    module: {
        loaders: [
            // Process any typescript or typescript-jsx files using the ts-loader
            //
            {
                test: /\.tsx?$/,
                loaders: ["ts-loader"]
            },

            // Process Sass files using the sass-loader first, and then with postcss,
            //  and finally with the raw-loader so we can convert the result into a 
            //  string and inject them into the 'styles' property of components (to 
            //  take advantage of view encapsulation)
            //
            {
                test: /\.scss$/,
                exclude: /node_modules/,
                loaders: ["raw-loader", "postcss-loader", "sass-loader"]
            },

            // Load any HTML files into raw strings so they can be included with
            //  the angular components in-line
            //
            {
                test: /\.html$/,
                loaders: ["html-loader"]
            }
        ]
    },

    // Configure postcss to run the autoprefixer plugin
    //
    postcss: function () {
        return [autoprefixer];
    }
}