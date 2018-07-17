import { Page } from 'puppeteer';
import { appUrl } from '../config';

describe('Sitters', () => {
  let page: Page;

  beforeEach(async () => {
    page = await browser.newPage();
    await page.goto(`${appUrl}/sitters`);
  });

  it('should add sitter', async () => {
    await addSitter({
      firstName: 'bob',
      lastName: 'idk',
      hourlyRate: 54,
      hourlyRateAfterMidnight: 12,
      hourlyRateBetweenBedtimeAndMidnight: 87,
    });

    await page.waitFor('li');
    await expect(page).toMatch('idk, bob');
  });

  it('should display sitter after added', async () => {
    await addSitter({
      firstName: 'three',
      lastName: 'dee',
      hourlyRate: 3,
      hourlyRateAfterMidnight: 12,
      hourlyRateBetweenBedtimeAndMidnight: 78,
    });

    await expect(page).toMatch('three');
    await expect(page).toMatch('dee');
    expect(await getInputValue('hourlyRate')).toMatch('3');
    expect(await getInputValue('hourlyRateBetweenBedtimeAndMidnight')).toMatch(
      '78'
    );
    expect(await getInputValue('hourlyRateAfterMidnight')).toMatch('12');
  });

  async function addSitter({
    firstName,
    lastName,
    hourlyRate,
    hourlyRateAfterMidnight,
    hourlyRateBetweenBedtimeAndMidnight,
  }) {
    await page.click('button#addSitter');
    await page.type('input#firstName', firstName);
    await page.type('input#lastName', lastName);
    await page.type('input#hourlyRate', String(hourlyRate));
    await page.type(
      'input#hourlyRateBetweenBedtimeAndMidnight',
      String(hourlyRateBetweenBedtimeAndMidnight)
    );
    await page.type(
      'input#hourlyRateAfterMidnight',
      String(hourlyRateAfterMidnight)
    );
    await page.click('button#saveAdd');
  }

  async function getInputValue(id: string): Promise<any> {
    const inputElement = await page.$(`input#${id}`);
    const value = await inputElement.getProperty('value');
    return value.jsonValue();
  }
});
