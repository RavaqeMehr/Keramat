export const sleep = (ms = 1000) => new Promise((resolve) => setTimeout(resolve, ms))

export const random = (min, max) => Math.floor(Math.random() * (max - min + 1) + min)

const numbers = '0123456789'

export const normalizeNumberInt = (input) => {
  let str = ''
  const inp = input.toString()
  for (const ch of inp) {
    if (numbers.includes(ch)) {
      str += ch
    }
  }

  if (str.length > 1 && str[0] === '0') {
    if (str[1] !== '.') {
      str = str.substring(1)
    }
  }

  return str === '' ? '0' : str
}

export const normalizeNumberFloat = (input) => {
  let str = ''
  const inp = input.toString()
  for (const ch of inp) {
    if (numbers.includes(ch)) {
      str += ch
    } else if (ch === '.' && !str.includes('.')) {
      str += ch
    }
  }

  if (str.length > 1 && str[0] === '0') {
    if (str[1] !== '.') {
      str = str.substring(1)
    }
  }

  return str === '' ? '0' : str
}

export const NumberWithCommas = (x) => x.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ',')

export const isNumeric = (n) => !isNaN(parseFloat(n)) && isFinite(n)

export const sizesString = ['B', 'KB', 'MB', 'GB', 'TB']
export const size2string = (sizeInByte, decimals = 2) => {
  let size = +sizeInByte
  let step = 0
  while (size > 1024) {
    size /= 1024
    step++
  }
  return `${size.toFixed(decimals)} ${sizesString[step]}`
}

export const duration2String = (seconds) => new Date(seconds * 1000).toISOString().slice(11, 19)

export const array2Percent = (...arr) => {
  const total = arr.reduce((a, b) => a + b, 0)
  const result = arr.map((x) => (x * 100) / total)
  // log('array2Percent', { arr, total, result })
  return result
}
