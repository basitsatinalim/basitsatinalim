document.addEventListener('alpine:init', () => {
	Alpine.store('userCart', {
		items: JSON.parse(window.localStorage.getItem('user_cart_items')) ?? [],
		total: window.localStorage.getItem('user_cart_total')
			? parseFloat(window.localStorage.getItem('user_cart_total'))
			: 0.0,
		count: window.localStorage.getItem('user_cart_count')
			? parseInt(window.localStorage.getItem('user_cart_count'))
			: 0,
		add(newItem) {
			const cartItem =
				this.items[this.items.findIndex(item => item.id === newItem.Id)]

			if (!cartItem) {
				newItem = {
					id: newItem.Id,
					category: newItem.Category,
					count: 1,
					amount: parseFloat(newItem.Price.Amount),
					currency: newItem.Price.Currency,
				}
				this.items.push(newItem)
				this.count += 1
				this.total += newItem.amount
				this.setLocalStorage()
			} else {
				this.items = this.items.map(item => {
					if (item.id !== newItem.Id) return item
					item.count += 1
					return item
				})
				this.total += cartItem.amount
				this.count += 1
				this.setLocalStorage()
			}
			console.log('item added to cart')
			Toastify({
				text: 'Item added to cart!',
				duration: 3000,
				close: true,
				gravity: 'bottom',
				position: 'right',
				stopOnFocus: true,
				style: {
					color: '#fff',
					height: '50px',
					bottom: '20px',
					right: '20px',
					'background-color': '#333',
					color: '#fff',
					padding: '15px',
					'border-radius': '5px',
					'box-shadow': '0 2px 5px rgba(0, 0, 0, 0.2)',
				},
				onClick: function () {},
			}).showToast()
		},
		getData: id => {
			fetch(`/Product/JsonDetails/${id}`)
				.then(response => response.json())
				.then(data => {
					Alpine.store(id, data)
				})
		},
		decreaseItem(id) {
			const cartItem = this.items.find(item => item.id === id)
			if (cartItem.count > 1) {
				this.items = this.items.map(item => {
					if (item.id !== cartItem.id) return item
					item.count -= 1
					return item
				})
				this.total -= cartItem.amount
				this.count -= 1
				this.setLocalStorage()
			}
		},
		increaseItem(id) {
			const cartItem = this.items.find(item => item.id === id)

			this.items = this.items.map(item => {
				if (item.id !== cartItem.id) return item
				item.count += 1
				return item
			})
			this.total += cartItem.amount
			this.count += 1
			this.setLocalStorage()
		},
		itemCount(id) {
			const cartItem = this.items.find(item => item.id === id)
			return cartItem
		},
		remove(id) {
			const cartItem = this.items.find(item => item.id === id)
			this.total -= cartItem.amount * cartItem.count
			this.count -= cartItem.count
			this.items = this.items.filter(item => item.id !== id)
			this.setLocalStorage()
		},
		removeLocalStorage() {
			window.localStorage.removeItem('user_cart_items')
			window.localStorage.removeItem('user_cart_total')
			window.localStorage.removeItem('user_cart_count')
		},
		setLocalStorage() {
			if (this.count === 0) this.removeLocalStorage()
			if (this.count < 0) this.removeLocalStorage()
			if (this.total < 0) this.removeLocalStorage()
			if (this.items.length === 0) this.removeLocalStorage()

			this.total = parseFloat(this.total.toFixed(2))

			window.localStorage.setItem('user_cart_items', JSON.stringify(this.items))
			window.localStorage.setItem('user_cart_total', this.total)
			window.localStorage.setItem('user_cart_count', this.count)
		},
	})

	Alpine.store('userPaymentInfo', {
		addressId: '',
		cardNumber: '',
		expirationDate: '',
		cvv: '',
		holderName: '',
		isConfirmedData: false,
		modal: false,
		orderStatus: false,
		orderId: '',
		isLoading: false,

		openModal() {
			this.modal = true
		},
		closeModal() {
			this.modal = false
		},
		setIsLoading(value) {
			this.isLoading = value
		},
		handleRadioChange() {
			this.addressId = document.querySelector(
				'input[name="product"]:checked'
			).id
			this.setIsConfirmed()
		},
		handleInputChange(event) {
			const { name, value } = event.target
			this[name] = value
			this.setIsConfirmed()
		},

		setIsConfirmed() {
			this.isConfirmedData =
				this.addressId !== '' &&
				this.cardNumber !== '' &&
				this.cardNumber.length === 19 &&
				this.expirationDate !== '' &&
				this.cvv !== '' &&
				this.holderName !== ''
		},
		applyOrder() {
			var forms = document.querySelectorAll('.needs-validation')
			Array.prototype.slice.call(forms).forEach(function (form) {
				if (!form.checkValidity()) {
					this.isConfirmedData = false
					form.classList.add('was-validated')
				}
			})

			const orderCheckout = {
				addressId: this.addressId,
				cardNumber: this.cardNumber.replace(/\s/g, ''),
				expirationDate: this.expirationDate,
				cvv: this.cvv,
				holderName: this.holderName,
				total: Alpine.store('userCart').total + 30.0,
				items: JSON.stringify(Alpine.store('userCart').items),
				count: Alpine.store('userCart').count,
			}

			if (this.isConfirmedData) {
				this.openModal()
				this.setIsLoading(true)
				console.log(orderCheckout)
				fetch('/Checkout', {
					method: 'POST',
					headers: {
						'Content-Type': 'application/json',
					},
					body: JSON.stringify(orderCheckout),
				})
					.then(response => response.json())
					.then(data => {
						this.setIsLoading(false)
						if (data.success) {
							Alpine.store('userCart').removeLocalStorage()
							this.orderStatus = true
							this.orderId = data.orderId
						} else {
							this.orderStatus = false
							this.orderId = ''
						}
					})
			} else {
				Toastify({
					text: 'Please fill all fields!',
					duration: 3000,
					close: true,
					gravity: 'bottom',
					position: 'right',
					stopOnFocus: true,
					className: '',
					style: {
						color: '#fff',
						height: '50px',
						bottom: '20px',
						right: '20px',
						'background-color': '#333',
						color: '#fff',
						padding: '15px',
						'border-radius': '5px',
						'box-shadow': '0 2px 5px rgba(0, 0, 0, 0.2)',
					},
					onClick: function () {},
				}).showToast()
			}
		},
	})
})
