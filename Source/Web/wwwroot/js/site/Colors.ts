class Colors {
    private static _colorClasses = [
        '#f44336', '#e91e63', '#9c27b0', '#673ab7', '#3f51b5', '#2196f3',
        '#03a9f4', '#00bcd4', '#009688', '#4caf50', '#8bc34a', '#cddc39',
        '#ffc107', '#ff9800', '#ff5722', '#795548', '#9e9e9e', '#607d8b'];

    static random(): string {
        return Colors._colorClasses[Math.floor(Math.random() * Colors._colorClasses.length)];
    }
}