
document.addEventListener('alpine:init', () => {
    Alpine.store('userCart', {
        items: JSON.parse(window.localStorage.getItem('user_cart_items')) ?? [],
        total: window.localStorage.getItem('user_cart_total') ? parseInt(window.localStorage.getItem('user_cart_total')): 0,
        count: window.localStorage.getItem('user_cart_count') ? parseInt(window.localStorage.getItem('user_cart_count')) : 0,
        add(newItem) {
            const cartItem = this.items.find(item => item.id === newItem.Id);

            if (!cartItem) {
                newItem = { id: newItem.Id, name: newItem.Name, price: parseFloat(newItem.Price) };
                this.items.push(newItem);
                this.total += newItem.price;
                this.count += 1;
                this.setLocalStorage();
            } else
                this.items = this.items.map((item) => {
                    if (item.id !== newItem.Id) return item;
                    item.count += 1;
                    item.total = item.price * item.count;
                    this.total += item.price;
                    this.count += 1;
                    this.setLocalStorage();
                    return item;
                });
        },
        remove(id) {
            const cartItem = this.items.find(item => item.id === id);
            if (cartItem.count > 1)
                this.items = this.items.map((item) => {
                    if (item.id !== id) return item;
                    item.count -= 1;
                    item.total = item.Price * item.count;
                    this.total -= item.Price;
                    this.count -= 1;
                    this.setLocalStorage();
                    return item;
                });
            else if (cartItem.count === 1) {
                this.items = this.items.filter((item) => item.id !== id);
                this.total -= cartItem.price;
                this.count -= 1;
                this.setLocalStorage();
            }
        },
        setLocalStorage() {
            window.localStorage.setItem('user_cart_items', JSON.stringify(this.items));
            window.localStorage.setItem('user_cart_total', this.total);
            window.localStorage.setItem('user_cart_count', this.count);
        }

    });

})



