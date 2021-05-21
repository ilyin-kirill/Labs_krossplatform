from django.db import models

# Create your models here.
class Product(models.Model):
	product_title = models.CharField('название товара', max_length = 50)
	product_text = models.TextField('описание товара')
	product_price = models.IntegerField('цена товара')

	def __str__(self):
		return self.product_title

	class Meta:
		verbose_name = 'Товар'
		verbose_name_plural = 'Товары'

class Review(models.Model):
	product = models.ForeignKey(Product, on_delete = models.CASCADE)
	author_name = models.CharField('имя автора', max_length = 50)
	review_text = models.CharField('текст отзыва', max_length = 200)
	pub_date = models.DateTimeField('дата публикации')

	def __str__(self):
		return self.author_name

	class Meta:
		verbose_name = 'Отзыв'
		verbose_name_plural = 'Отзывы'

