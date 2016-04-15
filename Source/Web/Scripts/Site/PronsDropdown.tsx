
class PronDropdown extends React.Component<any, any> {
    static _prons: string[] = ["s", "t", "r", "i", "p", "ɔ", "ɪ", "n", "ə", "d", "l", "v", "e", "m", "ʌ", "j", "u", "ʒ", "b", "o", "ʊ", "a", "ŋ", "æ", "h", "f", "ð", "ʃ", "k", "ɜ", "θ", "w", "ɑ", "ɡ", "z", "ɒ", " ", "u:", "ɔ:"];

    render() {
        var labels = PronDropdown._prons.map(p => {
            return <span className="label label-default">{p}</span>
        });
        return (
            <div className="dropdown-menu dropdown-menu-right prons-dropdown">
                {labels}
            </div>
        );
    }
}