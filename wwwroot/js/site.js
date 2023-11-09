
document.addEventListener('alpine:init', () => {
    Alpine.store('userCart', {
        items: JSON.parse(window.localStorage.getItem('user_cart_items')) ?? [],
        total: JSON.parse(window.localStorage.getItem('user_cart_total')) ?? [],
        count: window.localStorage.getItem('user_cart_count') ? parseInt(window.localStorage.getItem('user_cart_count')) : 0,
        add(newItem) {
            const cartItem = this.items.find(item => item.id === newItem.Id);

            if (!cartItem) {
                newItem = { id: newItem.Id, name: newItem.Name, count: 1, amount: parseFloat(newItem.Price.Amount), currency: newItem.Price.Currency };
                this.items.push(newItem);
                this.count += 1;

                var currencyIndex = this.total.findIndex((price) => price.currency == newItem.currency)
                if (currencyIndex != -1) {
                    this.total[currencyIndex].amount += newItem.amount;
                }
                else {
                    this.total.push({ amount: newItem.amount, currency: newItem.currency });
                };

                this.setLocalStorage();
            } else
                this.items = this.items.map((item) => {
                    if (item.id !== newItem.Id) return item;
                    item.count += 1;
                    this.total = this.total.map((price) => {
                        if (price.currency !== cartItem.currency) return price;
                        price.amount += cartItem.amount;
                        return price;
                    });

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
                    item.total = item.Price.Amount * item.count;
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
            window.localStorage.setItem('user_cart_total', JSON.stringify(this.total));
            window.localStorage.setItem('user_cart_count', this.count);
        }

    });

})



