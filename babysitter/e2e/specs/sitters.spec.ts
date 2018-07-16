import { appUrl } from '../config';

describe('Sitters', () => {
  it('should add sitter', async () => {
    const page = await browser.newPage();
    await page.goto(`${appUrl}/sitters`);

    await page.click('button#addSitter');
    await page.type('input#firstName', 'bob');
    await page.type('input#lastName', 'idk');
    await page.type('input#hourlyRate', '54');
    await page.type('input#hourlyRateBetweenBedtimeAndMidnight', '87');
    await page.type('input#hourlyRateAfterMidnight', '12');
    await page.click('button#saveAdd');

    await page.waitFor('li');

    // await expect(page).toMatch('idk, bob');
  });
});
