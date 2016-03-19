interface WordListProps extends React.Props<WordList> {
    words: Word[];
    keyword: string;
}

class WordList extends React.Component<WordListProps, any> {

    render() {
        var items = [];
        var keyword = this.props.keyword;
        this.props.words.forEach((w) => {
            if (w.spelling.indexOf(keyword) !== -1) {
                items.push(<WordItem word={w} key={w.spelling} />);
            }
        });

        return (
            <div id="word_list" className="clearfix">
                {items}
            </div>
        );
    }
}