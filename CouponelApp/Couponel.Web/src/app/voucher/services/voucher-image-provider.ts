import { Injectable } from '@angular/core';


@Injectable({
  providedIn: 'root'
})
export class VoucherImageProvider {
  private categoryImages =
    {
      Food:             '../../assets/images/restaurant.png',
      Auto:             '../../assets/images/auto.png',
      Electronics:      '../../assets/images/electronics.png',
      'Coffee&Snacks':  '../../assets/images/coffee.png',
      Entertainment:    '../../assets/images/entertainment.png',
      Fashion:          '../../assets/images/fashion.png',
      Accessories:      '../../assets/images/accessories.png',
      Home:             '../../assets/images/supplies.png',
      Sport:            '../../assets/images/sport.png',
      Others:           '../../assets/images/others.png'
    };

  public getCategoryImage(category: string): string{
    const result = this.categoryImages[category];
    if (result == null)
    {
      console.log('Not Found Image for the category ' + category);
      return '../../assets/images/coupon.png';
    }
    return result;
  }
}
