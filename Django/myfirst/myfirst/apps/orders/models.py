from django.db import models
from products.models import Product
# Create your models here.
class Order(models.Model):
	pub_date = models.DateTimeField('дата публикации')

	class Meta:
		verbose_name = 'Заказ'
		verbose_name_plural = 'Заказы'

class ProductSum(models.Model):
	order = models.ForeignKey(Order, on_delete = models.CASCADE)
	product = models.ForeignKey(Product, on_delete = models.CASCADE)
	amount = models.IntegerField('количество товара')

	class Meta:
		verbose_name = 'Количество и товар'
		verbose_name_plural = 'Количество и товары'