interface WordProps extends React.Props<WordItem> {
    word: Word;
    highlight?: {
        start: number;
        end: number;
    }
}

class WordItem extends React.Component<WordProps, any>{

    constructor(props: WordProps) {
        super(props);
    }

    render() {
        if (this.props.highlight) {
            var leftPart = this.props.word.spelling.substring(0, this.props.highlight.start);
            var highlight = this.props.word.spelling.substring(this.props.highlight.start, this.props.highlight.end);
            var rightPart = this.props.word.spelling.substring(this.props.highlight.end);
            return <span className="word">
                {leftPart}
                <span className="highlight">
                    {highlight}
                </span>
                {rightPart}
            </span>
        }
        return <span className="word">
            { this.props.word.spelling }
        </span>;
    }
}