interface WordListProps extends React.Props<WordList> {
    words: Word[];
    keyword: string;
}

class WordList extends React.Component<WordListProps, any> {

    render() {
        var items = [];
        var keyword = this.props.keyword;
        if (keyword) {
            this.props.words.forEach((w) => {
                var startIndex = w.spelling.indexOf(keyword);
                if (startIndex >= 0) {
                    var highlight = {
                        start: startIndex,
                        end: startIndex + this.props.keyword.length
                    };
                    items.push(<WordItem word={w} key={w.spelling} highlight={highlight} />);
                }
            });
        } else {
            this.props.words.forEach((w) => {
                items.push(<WordItem word={w} key={w.spelling} />);
            });
        }

        return (
            <div id="word_list" className="clearfix">
                {items}
            </div>
        );
    }
}