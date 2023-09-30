const gulp = require('gulp');
const sass = require('gulp-sass')(require('sass'));
const cssmin = require('gulp-cssmin');
const autoprefixer = require('gulp-autoprefixer');
const rename = require('gulp-rename');
const webpack = require('webpack-stream');
const cleanCSS = require('gulp-clean-css');
const named = require('vinyl-named');

function compileSass() {
    return gulp.src('./wwwroot/scss/**/*.scss')
       
        .pipe(sass().on('error', sass.logError))
        .pipe(autoprefixer({
            overrideBrowserslist: ['last 2 versions'],
            cascade: false
        }))
        .pipe(gulp.dest('./wwwroot/dist/css'));
}
function scripts() {
    return gulp.src('./wwwroot/js/enter.js') // Adjust the source directory as needed
        .pipe(named())
        .pipe(webpack({
            devtool: 'source-map'
        }))
        .pipe(gulp.dest('./wwwroot/dist/js')); // Adjust the output directory as needed
}
function minifyCSS() {
    return gulp.src(['./wwwroot/dist/css/**/*.css', '!./wwwroot/dist/css/**/*.min.css'])
        .pipe(cssmin())
        .pipe(cleanCSS())
        .pipe(rename({ suffix: '.min' }))
        .pipe(gulp.dest('./wwwroot/dist/css'));
}

function fonts() {
    return gulp.src(['./wwwroot/fonts/**/*'])
        .pipe(gulp.dest('./wwwroot/dist/fonts'));
}

function watch() {
    gulp.watch(['./wwwroot/scss/**/*.scss','./wwwroot/js/**/*.js'], gulp.series(compileSass,scripts));
}

exports.default =  gulp.series(fonts,compileSass,scripts,watch);
