import { CloudBaseLineTemplatePage } from './app.po';

describe('CloudBaseLine App', function() {
  let page: CloudBaseLineTemplatePage;

  beforeEach(() => {
    page = new CloudBaseLineTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
