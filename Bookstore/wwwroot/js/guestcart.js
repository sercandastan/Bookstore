$(function () {
    // MOD: Sepet badge'ini göster/gizle ve sayıyı ayarla
    function updateCartBadge(count) {
        var $badge = $('#cartBadge');
        if (count > 0) {
            $badge.text(count).removeClass('d-none'); // göster
        } else {
            $badge.addClass('d-none'); // gizle
        }
    }

    // Sayfa yüklendiğinde veya modal açıldığında sepetteki mevcut öğeleri çek,
    // hem modal tablosunu hem badge'i güncelle
    loadCartItems();         // MOD: sayfa ilk yüklemede badge'i ayarla
    $('#cartModal').on('show.bs.modal', loadCartItems);

    // 2) Sepet verisini çek ve tabloyu doldur
    function loadCartItems() {
        $.getJSON('/Cart/GetCartItems', function (items) {
            var $tbody = $('#cartItemsContainer').empty(),
                totalCount = 0,
                grandTotal = 0;

            items.forEach(function (item) {
                var lineTotal = item.price * item.quantity;
                totalCount += item.quantity;
                grandTotal += lineTotal;

                $tbody.append(
                    '<tr data-id="' + item.bookId + '">' +
                    '<td><img src="' + item.coverImage + '" width="50"/></td>' +
                    '<td>' + item.title + '</td>' +
                    '<td><input type="number" class="form-control form-control-sm qty-input" ' +
                    'min="1" value="' + item.quantity + '" style="width:70px"/></td>' +
                    '<td>₺' + item.price.toFixed(2) + '</td>' +
                    '<td class="line-total">₺' + lineTotal.toFixed(2) + '</td>' +
                    '<td><button class="btn btn-sm btn-danger remove-item">' +
                    '<i class="bi bi-trash"></i>' +
                    '</button></td>' +
                    '</tr>'
                );
            });

            $('#cartTotalCount').text(totalCount);
            $('#cartGrandTotal').text(grandTotal.toFixed(2));

            // MOD: Badge'i de güncelle
            updateCartBadge(totalCount);
        });
    }

    // 3) Adet değişince
    $(document).on('change', '.qty-input', function () {
        var $tr = $(this).closest('tr'),
            bookId = $tr.data('id'),
            qty = parseInt(this.value) || 1;

        $.post('/Cart/UpdateCartItem', { bookId: bookId, quantity: qty })
            .done(loadCartItems);
    });

    // 4) Öğeyi silince
    $(document).on('click', '.remove-item', function () {
        var bookId = $(this).closest('tr').data('id');
        $.post('/Cart/RemoveFromCart', { bookId: bookId })
            .done(loadCartItems);
    });

    // 5) Sepete ekleme butonu – AJAX ile çağır, toast ve badge güncelle
    $(document).on('click', '.cart-button', function (e) {
        e.preventDefault();

        var bookId = $(this).data('book-id'),
            token = $('input[name="__RequestVerificationToken"]').val();

        $.ajax({
            url: '/Cart/Add',
            method: 'POST',
            dataType: 'html',              // controller’dan partial HTML geliyor
            data: {
                bookId: bookId,
                quantity: 1,
                __RequestVerificationToken: token
            }
        })
            .done(function (htmlPartial) {
                // MOD: Önceki toast’ı kaldır, yenisini ekle
                $('.toast-container').remove();
                $('body').append(htmlPartial);

                // MOD: Badge’i +1 arttır
                var current = parseInt($('#cartBadge').text(), 10) || 0;
                updateCartBadge(current + 1);

                // MOD: Eğer modal açıksa içeriği yenile
                if ($('#cartModal').hasClass('show')) {
                    loadCartItems();
                }
            })
            .fail(function () {
                console.error('Sepete eklenirken bir hata oluştu.');
            });
    });
});
