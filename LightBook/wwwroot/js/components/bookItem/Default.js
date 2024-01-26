const books = document.querySelectorAll('.book');
books.forEach(book => {
    const id = book.dataset.id;
    let editBtn = book.querySelector('.edit');

    editBtn.addEventListener('click', () => {
        book.querySelector(`[for="Readed-${id}"]`).classList.add('d-none');
        editBtn.classList.add('disabled');
        book.querySelector('.editable-group').classList.remove('d-none');
    });

    book.querySelector('.cancel').addEventListener('click', () => {
        location.reload();
    });
});