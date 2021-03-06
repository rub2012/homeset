﻿// para actualizar las librerias ejecutar 'npm run build' cada vez que se actualiza las dependencias


const path = require('path');
const webpack = require('webpack');
const CopyWebpackPlugin = require('copy-webpack-plugin');

// assets.js
const Assets = require('./assets');

module.exports = {
    entry: {
        app: "./app.js",
    },
    output: {
        path: __dirname + "/wwwroot/js/",
        filename: "[name].bundle.js"
    },
    plugins: [
        new CopyWebpackPlugin(
            Assets.map(asset => {
                return {
                    from: path.resolve(__dirname, `./node_modules/${asset}`),
                    to: path.resolve(__dirname, './wwwroot/lib')
                };
            })
        )
    ]
};
