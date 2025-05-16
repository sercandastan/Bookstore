
$(function () {
    // --------------------------------------------------
    // 1) Sepet badge'ini göster/gizle ve sayıyı ayarla
    // --------------------------------------------------
    function updateCartBadge(count) {
        const $badge = $('#cartBadge');
        if (count > 0) {
            $badge.text(count).removeClass('d-none');
        } else {
            $badge.text('').addClass('d-none');
        }
    }

    // --------------------------------------------------
    // 2) Sepet verisini çekip modal & badge'i güncelle
    // --------------------------------------------------
    function loadCartItems() {
        $.getJSON('/Cart/GetCartItems', function (items) {
            const $tbody = $('#cartItemsContainer').empty();
            let totalCount = 0;
            let grandTotal = 0;

            items.forEach(item => {
                const lineTotal = item.price * item.quantity;
                totalCount += item.quantity;
                grandTotal += lineTotal;

                $tbody.append(
                    `<tr data-id="${item.bookId}">
                        <td><img src="${item.coverImage}" width="50"/></td>
                        <td>${item.title}</td>
                        <td>
                          <input type="number"
                                 class="form-control form-control-sm qty-input"
                                 min="1"
                                 value="${item.quantity}"
                                 style="width:70px"/>
                        </td>
                        <td>₺${item.price.toFixed(2)}</td>
                        <td class="line-total">₺${lineTotal.toFixed(2)}</td>
                        <td>
                          <button class="btn btn-sm btn-danger remove-item">
                            <i class="bi bi-trash"></i>
                          </button>
                        </td>
                    </tr>`
                );
            });

            $('#cartTotalCount').text(totalCount);
            $('#cartGrandTotal').text(grandTotal.toFixed(2));
            updateCartBadge(totalCount);
        });
    }

    // Sayfa yüklendiğinde ve modal açıldığında yükle
    loadCartItems();
    $('#cartModal').on('show.bs.modal', loadCartItems);

    // --------------------------------------------------
    // 3) Adet güncelle
    // --------------------------------------------------
    $(document).on('change', '.qty-input', function () {
        const $tr = $(this).closest('tr');
        const bookId = $tr.data('id');
        const qty = parseInt(this.value, 10) || 1;

        $.post('/Cart/UpdateCartItem',
            { bookId: bookId, quantity: qty })
            .done(loadCartItems);
    });

    // --------------------------------------------------
    // 4) Öğeyi sil
    // --------------------------------------------------
    $(document).on('click', '.remove-item', function () {
        const bookId = $(this).closest('tr').data('id');

        $.post('/Cart/RemoveFromCart',
            { bookId: bookId })
            .done(loadCartItems);
    });

    // --------------------------------------------------
    // 5) Sepeti temizle
    // --------------------------------------------------
    $(document).on('click', '#clearCartButton', function (e) {
        e.preventDefault();
        console.log('🍺 clearCartButton clicked');
        $.post('/Cart/Clear')
            .done(function () {
                
                loadCartItems();
            })
            .fail(function (err) {
                console.error('❌ /Cart/Clear failed', err);
            });
    });

    // --------------------------------------------------
    // 6) Sepete ekle
    // --------------------------------------------------
    $(document).on('click', '.cart-button', function (e) {
        e.preventDefault();
        const bookId = $(this).data('book-id');

        $.post('/Cart/Add',
            { bookId: bookId, quantity: 1 },
            function (htmlPartial) {
                // Toast partial'ı inject et
                $('.toast-container').remove();
                $('body').append(htmlPartial);

                // Sepeti yeniden yükle
                loadCartItems();
            },
            'html'
        );
    });
});
