describe('Welcome Page', () => {
  it('should say welcome', async () => {
    const page = await browser.newPage();
    await page.goto('https://localhost:5001');

    await expect(page).toMatch('Welcome');
  });
});
