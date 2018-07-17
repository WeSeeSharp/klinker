const path = require('path');
const webpack = require('webpack');
const HtmlWebpackPlugin = require('html-webpack-plugin');
const { CheckerPlugin } = require('awesome-typescript-loader');

module.exports = function(env) {
  return {
    mode: isDev(env) ? 'development' : 'production',
    devtool: isDev(env) ? 'source-map' : 'cheap-module-source-map',
    optimization: getOptimization(env),
    entry: {
      main: path.resolve(__dirname, 'src', 'index.tsx'),
    },
    output: {
      path: path.resolve(__dirname, 'dist'),
      filename: isDev(env) ? '[name].js' : '[name].[hash].min.js',
    },
    resolve: {
      extensions: ['.ts', '.tsx', '.js', '.jsx', '.json'],
    },
    module: {
      rules: [
        {
          test: /\.tsx?$/,
          exclude: /node_modules/,
          use: 'babel-loader',
        },
        {
          test: /\.scss$/,
          use: [
            { loader: 'style-loader', options: { sourceMap: true } },
            {
              loader: 'css-loader',
              options: { sourceMap: true, modules: true, importLoaders: 1 },
            },
            { loader: 'postcss-loader', options: { sourceMap: true } },
            { loader: 'sass-loader', options: { sourceMap: true } },
          ],
        },
      ],
    },
    plugins: [...(isDev(env) ? getDevPlugins(env) : getProductionPlugins(env))],
    devServer: {
      publicPath: '/',
      contentBase: path.resolve(__dirname, 'dist'),
      compress: true,
      historyApiFallback: true,
      hot: true,
      inline: true,
      open: true,
    },
  };
};

function isDev(env) {
  return env === 'dev';
}

function getOptimization(env) {
  return {
    minimize: !isDev(env),
    splitChunks: isDev(env) ? undefined : getSplitChunks(),
  };
}

function getSplitChunks() {
  return {
    minSize: 30000,
    maxSize: 0,
    minChunks: 2,
    maxAsyncRequests: 5,
    maxInitialRequests: 3,
    automaticNameDelimiter: '.',
    name: true,
    cacheGroups: {
      vendors: {
        test: /[\\/]node_modules[\\/]/,
        priority: -10,
      },
      default: {
        minChunks: 2,
        priority: -20,
        reuseExistingChunk: true,
      },
    },
  };
}

function getDevPlugins(env) {
  return [...getBasePlugins(env), new webpack.HotModuleReplacementPlugin()];
}

function getProductionPlugins(env) {
  return [...getBasePlugins(env)];
}

function getBasePlugins(env) {
  return [
    new CheckerPlugin(),
    new webpack.DefinePlugin({
      'process.env': {
        NODE_ENV: JSON.stringify(env),
      },
    }),
    new HtmlWebpackPlugin({
      template: path.resolve(__dirname, 'src', 'index.html'),
      inject: 'body',
    }),
  ];
}
