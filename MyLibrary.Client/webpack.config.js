const path = require("path");

module.exports = {
    entry: {
        books: "./apps/books",
    },
    output: {
        path: path.resolve(__dirname, "../MyLibrary.WebApp/wwwroot/scripts"),
        filename: "[name].js",
    },
    module: {
        rules: [{
            test: /\.(js|jsx)$/,
            exclude: /node_modules/,
            use: {
                loader: "babel-loader",
            },
        }, ],
    },
    devtool: "inline-source-map",
    resolve: {
        extensions: [".jsx", ".js"],
    },
};