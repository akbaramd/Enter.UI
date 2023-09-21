const gulp = require('gulp');
const sass = require('gulp-sass')(require('sass'));
const cssmin = require('gulp-cssmin');
const autoprefixer = require('gulp-autoprefixer');
const rename = require('gulp-rename');
const cleanCSS = require('gulp-clean-css');

function compileSass() {
    return gulp.src('./wwwroot/scss/**/*.scss')
       
        .pipe(sass().on('error', sass.logError))
        .pipe(autoprefixer({
            overrideBrowserslist: ['last 2 versions'],
            cascade: false
        }))
        .pipe(gulp.dest('./wwwroot/dist/css'));
}

function minifyCSS() {
    return gulp.src(['./wwwroot/dist/css/**/*.css', '!./wwwroot/dist/css/**/*.min.css'])
        .pipe(cssmin())
        .pipe(cleanCSS())
        .pipe(rename({ suffix: '.min' }))
        .pipe(gulp.dest('./wwwroot/dist/css'));
}

function watch() {
    gulp.watch('./wwwroot/**/*.scss', gulp.series(compileSass, minifyCSS));
}

exports.default = watch;
