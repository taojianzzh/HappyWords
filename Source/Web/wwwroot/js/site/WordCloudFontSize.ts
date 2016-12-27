class WordCloudFontSize {
    private _min: number;
    private _max: number;
    private _count: number;
    private _sum: number;

    constructor(min: number, max: number, count: number) {
        this._min = min;
        this._max = max;
        this._count = count;
        this._sum = min * count + (max - min) * count / 10;
    }

    next(): number {
        var next = this._min;
        var remaining = this._sum - this._count * this._min;
        if (remaining > 0) {
            var next = Math.min(Math.random() * remaining / this._count * 5 + this._min, this._max);
        }
        this._count--;
        this._sum -= next;
        return next;
    }
}