const path = require('path');
module.exports = {
    entry: './wwwroot/js/enter.js', // Replace with your entry point
    output: {
        filename: 'enter.js',
        path: path.resolve(__dirname, './wwwroot/dist/js') // Replace with your output path
    },
};