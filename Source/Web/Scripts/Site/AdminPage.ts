class AdminPage {
    constructor() {
        $(document).ready(() => {
            $('#add_word button').click(() => {
                var word = $('#add_word input').val();
                if (word) {
                    $.post('/api/word', { '': word }, () => {
                        alert('your word has been added.');
                    });
                }
            });
        });
    }
}