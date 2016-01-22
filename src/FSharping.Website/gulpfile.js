var gulp = require('gulp-param')(require('gulp'), process.argv);
var concat = require("gulp-concat"),
    cssmin = require("gulp-cssmin"),
    uglify = require("gulp-uglify"),
    debug = require('gulp-debug'),
    del = require('del'),
    less = require('gulp-less'),
    rev = require('gulp-rev-append');

// paths    
var paths = {
    webroot: "wwwroot/",
    packagesRoot: "bower_components/",
    buildrootDebug: "bin/Debug/",
    buildrootRelease: "../../build/app/"
};


paths.copyFolders = ["views", "strings", [paths.webroot + "img", "img"], "data"];

paths.jsSrc = paths.webroot + "js/*.js";
paths.jsDest = "js/site.min.js";
paths.cssSrc = paths.webroot + "css/*.less";
paths.cssDest = "css/site.min.css";
paths.fontsDest = "fonts/";

function destination(isRelease, path) {
    return (isRelease ? paths.buildrootRelease : paths.buildrootDebug) + path;
}

// packages paths
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
gulp.task('clean:js', function (release) {
    return del([destination(release, paths.jsDest)], { force: true });
});

gulp.task("clean:css", function (release) {
    return del([destination(release, paths.cssDest)], { force: true });
});

gulp.task("clean:fonts", function (release) {
    return del([destination(release, paths.fontsDest)], { force: true });
});

gulp.task("clean:favicons", function (release) {
    return del([
        destination(release, "*.png"),
        destination(release, "*.xml"),
        destination(release, "*.ico"),
        destination(release, "*.svg"),
        destination(release, "*.json")], { force: true });
});

gulp.task("clean:folders", function (release) {
    paths.copyFolders.forEach(function (entry) {
        if (Array === entry.constructor) {
            entry = entry[1]; // use dest folder
        }
        del([destination(release, entry + "/**/*")], { force: true });
    });
    return;
});

// minification
gulp.task("compile:js", ["clean:js"], function (release) {
    return gulp.src(scripts)
        .pipe(debug())
        .pipe(concat(destination(release, paths.jsDest)))
        .pipe(uglify())
        .pipe(gulp.dest("."));
});

gulp.task("compile:css", ["clean:css"], function (release) {
    return gulp.src(styles)
        .pipe(less())
        .pipe(debug())
        .pipe(concat(destination(release, paths.cssDest)))
        .pipe(cssmin())
        .pipe(gulp.dest("."));
});

gulp.task("compile:fonts", ["clean:fonts"], function (release) {
    return gulp.src(fonts).pipe(gulp.dest(destination(release, "fonts")));
});

gulp.task("compile:favicons", ["clean:favicons"], function (release) {
    return gulp.src(paths.webroot + "*.{png,xml,ico,svg,json}")
        .pipe(debug())
        .pipe(gulp.dest(destination(release, "")));
});

gulp.task("compile:folders", ["clean:folders"], function (release) {
    paths.copyFolders.forEach(function (entry) {
        var src = entry;
        var dest = entry;
        if (Array === entry.constructor) {
            src = entry[0];
            dest = entry[1];
        }
        gulp.src(src + "/**/*").pipe(debug()).pipe(gulp.dest(destination(release, dest)));
    });
    return;
});

// globals
gulp.task("precompile", ["compile:js", "compile:css", "compile:fonts", "compile:favicons", "compile:folders"]);

gulp.task("compile", ["precompile"], function (release) {
    var indexDes = destination(release, "views/layout.html");
    return gulp.src(indexDes)
      .pipe(rev())
      .pipe(gulp.dest(destination(release, "views")));
});