var gulp = require("gulp"),
    rimraf = require("rimraf"),
    concat = require("gulp-concat"),
    cssmin = require("gulp-cssmin"),
    uglify = require("gulp-uglify"),
    debug = require('gulp-debug');
    watch = require('gulp-watch');

// paths    
var paths = {
    webroot: "wwwroot/",
    buildroot: ".wwwbuild/",
    packagesRoot: "bower_components/",
    debugBin: "bin/Debug/",
};

paths.webHtmlSrc = "views/";
paths.webHtmlDest = paths.debugBin + paths.webHtmlSrc;

paths.jsSrc = paths.webroot + "js/*.js";
paths.jsDest = paths.buildroot + "js/site.min.js";

paths.cssSrc = paths.webroot + "css/*.css";
paths.cssDest = paths.buildroot + "css/site.min.css";

paths.fontsDest = paths.buildroot + "fonts/";

paths.packages = {};
paths.packages.jquery = paths.packagesRoot + "jquery/dist/";
paths.packages.bootstrap = paths.packagesRoot + "bootstrap/dist/";
paths.packages.fontawesome = paths.packagesRoot + "fontawesome/";

// scripts, fonts & styles
var scripts = [];
var styles = [];
var fonts = [];
    
// jquery
scripts.push(paths.packages.jquery + "jquery.js");
    
// bootstrap
scripts.push(paths.packages.bootstrap + "js/bootstrap.js");
styles.push(paths.packages.bootstrap + "css/bootstrap.css"/*, paths.packages.bootstrap + "css/bootstrap-theme.css"*/);
fonts.push(paths.packages.bootstrap + "fonts/*.*");

// fontawesome
styles.push(paths.packages.fontawesome + "css/font-awesome.css");
fonts.push(paths.packages.fontawesome + "fonts/*.*");

// custom scripts & styles
scripts.push(paths.jsSrc);
styles.push(paths.cssSrc);


// clean tasks
gulp.task("clean:js", function (cb) {
    return rimraf(paths.jsDest, cb);
});

gulp.task("clean:css", function (cb) {
    return rimraf(paths.cssDest, cb);
});

gulp.task("clean:fonts", function (cb) {
    return rimraf(paths.fontsDest, cb);
});

// minification
gulp.task("compile:js", ["clean:js"], function () {
    return gulp.src(scripts)
        .pipe(debug())
        .pipe(concat(paths.jsDest))
        .pipe(uglify())
        .pipe(gulp.dest("."));
});

gulp.task("compile:css", ["clean:css"], function () {
    return gulp.src(styles)
        .pipe(debug())
        .pipe(concat(paths.cssDest))
        .pipe(cssmin())
        .pipe(gulp.dest("."));
});

gulp.task("compile:fonts", ["clean:fonts"], function () {
    return gulp.src(fonts)
        .pipe(gulp.dest(paths.fontsDest));
});

// copy to bin


// globals
gulp.task("compile", ["compile:js", "compile:css", "compile:fonts"]);
gulp.task("deploy:www",["compile"], function () {
    return gulp.src(paths.buildroot + "**/*")
        .pipe(debug())
        .pipe(gulp.dest(paths.debugBin));
});
gulp.task("deploy:all", ["deploy:www"], function () {
    return gulp.src(paths.webHtmlSrc + "**/*")
        .pipe(debug())
        .pipe(gulp.dest(paths.webHtmlDest));
});
