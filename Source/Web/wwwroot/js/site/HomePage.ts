
declare var WordCloud: any;

class HomePage {

    constructor() {
        $(document).ready(() => {
            this._LoadWords();
        });
    }

    private _LoadWords() {
        $.get('/api/word/top200', (words: Word[]) => {
            this._DrawWordCloud(words);
        });
    }

    private _DrawWordCloud(words: Word[]) {

        var fontSize = new WordCloudFontSize(10, 120, words.length);
        var width = $('#home_page').width();
        var height = $('#home_page').height();
        var newWidth = Math.round(Math.min(width, height / 3 * 4));
        var newHeight = Math.round(Math.min(width / 4 * 3, height));
        var canvas = $('#word_cloud');
        canvas.attr('width', newWidth);
        canvas.attr('height', newHeight);

        var options = {
            list: words.map((w) => {
                return [w.spelling, fontSize.next()]
            }).sort((a, b) => {
                return (a[1] < b[1] ? 1 : -1);
            }),
            gridSize: 15,
            origin: [newWidth / 2, newHeight / 2],
            fontFamily: 'Roboto',
            clearCanvas: true,
            wait: 10,
            shuffle: true,
            rotateRatio: 0.3,
            shape: 'circle',
            color: () => {
                return Colors.random();
            }
        };
        
        WordCloud(canvas[0], options);
    }
}