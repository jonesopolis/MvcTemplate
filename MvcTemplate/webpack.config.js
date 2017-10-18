/// <binding BeforeBuild='Run - Development' />
var path = require('path');
const ExtractTextPlugin = require("extract-text-webpack-plugin");

module.exports = {
    entry: {
        main: './App/Main'
    },
    module: {
        loaders: [
            {
                test: /\.js$/,
                loader: 'babel-loader',
                query: {
                    presets: ['es2015']
                }
            },
            {
                test: /\.less$/,
                use: ExtractTextPlugin.extract({
                    use: [{
                        loader: "css-loader?sourceMap"
                    }, {
                        loader: "less-loader?sourceMap"
                    }]
                })
            },
            {
                test: /\.(svg|ttf|woff2|woff|eot)$/,
                loader: 'file-loader',
                options: {
                    name: './[name].[ext]?[hash]'
                }
            }]
    },
    output: {
        publicPath: "/js/",
        path: path.join(__dirname, '/wwwroot/'),
        filename: 'site.min.js',
        library: 'app',
        libraryTarget: 'var'
    },
    resolve: {
        modules: [
            path.resolve('./App'),
            path.resolve('./node_modules')
        ]
    },
    plugins: [
        new ExtractTextPlugin("./site.css")
    ],
    devtool: 'inline-source-map'
};