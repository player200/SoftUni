const gulp = require('gulp')
const minifyHtml = require('gulp-htmlmin')
const rename = require('gulp-rename')

gulp.task('minify-html', () => {
    gulp.src('views/*.html')
        .pipe(minifyHtml({ collapseWhitespace: true }))
        .pipe(rename({
            suffix: '.min'
        }))
        .pipe(gulp.dest('views'))
})