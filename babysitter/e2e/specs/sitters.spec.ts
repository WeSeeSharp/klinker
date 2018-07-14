describe('Sitter', () => {
  it('should show empty sitters', async () => {
    const page = await browser.newPage();
    await page.goto('https://localhost:5001/sitters');

    const items = await page.select('li');
    expect(items).toHaveLength(0);
  });
});
