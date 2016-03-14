var AdminPage = (function () {
    function AdminPage() {
        $(document).ready(function () {
            $('#add_word button').click(function () {
                var word = $('#add_word input').val();
                if (word) {
                    $.post('/api/word', { '': word }, function () {
                        alert('your word has been added.');
                    });
                }
            });
        });
    }
    return AdminPage;
})();
//# sourceMappingURL=AdminPage.js.map