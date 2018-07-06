import { MyFisrtProjectASPNETZEROTemplatePage } from './app.po';

describe('MyFisrtProjectASPNETZERO App', function() {
  let page: MyFisrtProjectASPNETZEROTemplatePage;

  beforeEach(() => {
    page = new MyFisrtProjectASPNETZEROTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
