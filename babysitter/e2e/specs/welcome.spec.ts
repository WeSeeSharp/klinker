import { appUrl } from '../config';

describe('Welcome Page', () => {
  it('should say welcome', async () => {
    const page = await browser.newPage();
    await page.goto(appUrl);

    await expect(page).toMatch('Welcome');
  });
});
