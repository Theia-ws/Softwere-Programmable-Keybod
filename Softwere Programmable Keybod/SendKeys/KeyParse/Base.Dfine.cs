using System;

namespace WS.Theia.Library.SendKeys.KeyParse {
	partial class Base {

		protected static EventHandler ParseException {
			get;
		} = new EventHandler((Base keyParseInfo, char[] chars, int charCounter) => {
			throw new ArgumentException("keys 有効なキー入力ではありません。", nameof(chars));
		});
		protected static EventHandler GetPreCharKeyCode {
			get;
		} = new EventHandler((Base keyParseInfo, char[] chars, int charCounter) => {
			return chars[charCounter - 1];
		});

		public static Base[] ConbinationKeyParseInfoList {
			get;
		} = new Base[] {
			new Normal('(',ParseException,0,' ',null),
			new Normal(')',ParseException,0,' ',null),
			new Combination('%',null,0,(char)VK.VK_MENU,null) ,
			new Combination('^',null,0,(char)VK.VK_CONTROL,null) ,
			new Normal('{',null,0,' ',new Base[]{
				new Normal('%',null,0,' ',new Base[]{
					new NormalLoop(' ',null,KeyboardFlag.Unicode,'%',null),
					new Normal('}',null,KeyboardFlag.Unicode,'%',null),
					new Normal(null,ParseException,0,' ',null)
				}),
				new Normal('^',null,0,' ',new Base[]{
					new NormalLoop(' ',null,KeyboardFlag.Unicode,'^',null),
					new Normal('}',null,KeyboardFlag.Unicode,'^',null),
					new Normal(null,ParseException,0,' ',null)
				}),
				new Normal('{',null,0,' ',new Base[]{
					new NormalLoop(' ',null,KeyboardFlag.Unicode,'{',null),
					new Normal('}',null,KeyboardFlag.Unicode,'{',null),
					new Normal(null,ParseException,0,' ',null)
				}),
				new Normal('}',null,0,' ',new Base[]{
					new NormalLoop(' ',null,KeyboardFlag.Unicode,'}',null),
					new Normal('}',null,KeyboardFlag.Unicode,'}',null),
					new Normal(null,ParseException,0,' ',null)
				}),
				new Normal('+',null,0,' ',new Base[]{
					new NormalLoop(' ',null,KeyboardFlag.Unicode,'+',null),
					new Normal('}',null,KeyboardFlag.Unicode,'+',null),
					new Normal(null,ParseException,0,' ',null)
				}),
				new Normal('A',null,0,' ',new Base[]{
					new Normal('D',null,0,' ',new Base[]{
						new Normal('D',null,0,' ',new Base[]{
							new NormalLoop(' ',null,0,(char)VK.VK_ADD,null) ,
							new Normal('}',null,0,(char)VK.VK_ADD,null),
							new Normal(null,ParseException,0,' ',null)
						}),
						new Normal(null,ParseException,0,' ',null)
					}),
					new NormalLoop(' ',null,KeyboardFlag.Unicode,'A',null),
					new Normal('}',null,KeyboardFlag.Unicode,'A',null),
					new Normal(null,ParseException,0,' ',null)
				}),
				new Normal('B',null,0,' ', new Base[]{
					new Normal('A',null,0,' ',new Base[]{
						new Normal('C',null,0,' ',new Base[]{
							new Normal('K',null,0,' ',new Base[]{
								new Normal('S',null,0,' ',new Base[]{
									new Normal('P',null,0,' ',new Base[]{
										new Normal('A',null,0,' ',new Base[]{
											new Normal('C',null,0,' ',new Base[]{
												new Normal('E',null,0,' ',new Base[]{
													new NormalLoop(' ',null,0,(char)VK.VK_BACK,null),
													new Normal('}',null,0,(char)VK.VK_BACK,null),
													new Normal(null,ParseException,0,' ',null)
												}),
												new Normal(null,ParseException,0,' ',null)
											}),
											new Normal(null,ParseException,0,' ',null)
										}),
										new Normal(null,ParseException,0,' ',null)
									}),
									new Normal(null,ParseException,0,' ',null)
								}),
								new Normal(null,ParseException,0,' ',null)
							}),
							new Normal(null,ParseException,0,' ',null)
						}),
						new Normal(null,ParseException,0,' ',null)
					}),
					new Normal('K',null,0,' ',new Base[]{
						new Normal('S',null,0,' ',new Base[]{
							new Normal('P',null,0,' ',new Base[]{
								new NormalLoop(' ',null,0,(char)VK.VK_BACK,null),
								new Normal('}',null,0,(char)VK.VK_BACK,null),
								new Normal(null,ParseException,0,' ',null)
							}),
							new Normal(null,ParseException,0,' ',null)
						}),
						new Normal(null,ParseException,0,' ',null)
					}),
					new Normal('R',null,0,' ',new Base[]{
						new Normal('E',null,0,' ',new Base[]{
							new Normal('A',null,0,' ',new Base[]{
								new Normal('K',null,0,' ',new Base[]{
									new NormalLoop(' ',null,0,(char)VK.VK_CANCEL,null),
									new Normal('}',null,0,(char)VK.VK_CANCEL,null),
									new Normal(null,ParseException,0,' ',null)
								}),
								new Normal(null,ParseException,0,' ',null)
							}),
							new Normal(null,ParseException,0,' ',null)
						}),
						new Normal(null,ParseException,0,' ',null)
					}),
					new Normal('S',null,0,' ',new Base[]{
						new NormalLoop(' ',null,0,(char)VK.VK_BACK,null),
						new Normal('}',null,0,(char)VK.VK_BACK,null),
						new Normal(null,ParseException,0,' ',null)
					}),
						new NormalLoop(' ',null,KeyboardFlag.Unicode,'B',null),
						new Normal('}',null,KeyboardFlag.Unicode,'B',null),
						new Normal(null,ParseException,0,' ',null)
				}),
				new Normal('C',null,0,' ',new Base[]{
					new Normal('A',null,0,' ',new Base[]{
						new Normal('P',null,0,' ',new Base[]{
							new Normal('S',null,0,' ',new Base[]{
								new Normal('L',null,0,' ',new Base[]{
									new Normal('O',null,0,' ',new Base[]{
										new Normal('C',null,0,' ',new Base[]{
											new Normal('K',null,0,' ',new Base[]{
												new NormalLoop(' ',null,0,(char)VK.VK_CAPITAL,null),
												new Normal('}',null,0,(char)VK.VK_CAPITAL,null),
												new Normal(null,ParseException,0,' ',null)
											}),
											new Normal(null,ParseException,0,' ',null)
										}),
										new Normal(null,ParseException,0,' ',null)
									}),
									new Normal(null,ParseException,0,' ',null)
								}),
								new Normal(null,ParseException,0,' ',null)
							}),
							new Normal(null,ParseException,0,' ',null)
						}),
						new Normal(null,ParseException,0,' ',null)
						}),
					new NormalLoop(' ',null,KeyboardFlag.Unicode,'C',null),
					new Normal('}',null,KeyboardFlag.Unicode,'C',null),
					new Normal(null,ParseException,0,' ',null)
				}),
				new Normal('D',null,0,' ',new Base[]{
					new Normal('E',null,0,' ',new Base[]{
						new Normal('L',null,0,' ',new Base[]{
							new Normal('E',null,0,' ',new Base[]{
								new Normal('T',null,0,' ',new Base[]{
									new Normal('E',null,0,' ',new Base[]{
										new NormalLoop(' ',null,0,(char)VK.VK_DELETE,null),
										new Normal('}',null,0,(char)VK.VK_DELETE,null),
										new Normal(null,ParseException,0,' ',null)
									}),
									new Normal(null,ParseException,0,' ',null)
								}),
								new Normal(null,ParseException,0,' ',null)
							}),
							new Normal(null,ParseException,0,' ',null)
						}),
						new NormalLoop(' ',null,0,(char)VK.VK_DELETE,null),
						new Normal('}',null,0,(char)VK.VK_DELETE,null),
						new Normal(null,ParseException,0,' ',null)
					}),
					new Normal('I',null,0,' ',new Base[]{
						new Normal('V',null,0,' ',new Base[]{
							new Normal('I',null,0,' ',new Base[]{
								new Normal('D',null,0,' ',new Base[]{
									new Normal('E',null,0,' ',new Base[]{
										new NormalLoop(' ',null,0,(char)VK.VK_DIVIDE,null),
										new Normal('}',null,0,(char)VK.VK_DIVIDE,null),
										new Normal(null,ParseException,0,' ',null)
									}),
									new Normal(null,ParseException,0,' ',null)
								}),
								new Normal(null,ParseException,0,' ',null)
							}),
							new Normal(null,ParseException,0,' ',null)
						}),
						new Normal(null,ParseException,0,' ',null)
					}),
					new Normal('O',null,0,' ',new Base[]{
						new Normal('W',null,0,' ',new Base[]{
							new Normal('N',null,0,' ',new Base[]{
								new NormalLoop(' ',null,0,(char)VK.VK_DOWN,null),
								new Normal('}',null,0,(char)VK.VK_DOWN,null),
								new Normal(null,ParseException,0,' ',null)
							}),
							new Normal(null,ParseException,0,' ',null)
						}),
						new Normal(null,ParseException,0,' ',null)
					}),
					new NormalLoop(' ',null,KeyboardFlag.Unicode,'D',null),
					new Normal('}',null,KeyboardFlag.Unicode,'D',null),
					new Normal(null,ParseException,0,' ',null)
				}),
				new Normal('E',null,0,' ',new Base[]{
					new Normal('N',null,0,' ',new Base[]{
						new Normal('D',null,0,' ',new Base[]{
							new NormalLoop(' ',null,0,(char)VK.VK_END,null),
							new Normal('}',null,0,(char)VK.VK_END,null),
							new Normal(null,ParseException,0,' ',null)
						}),
						new Normal('T',null,0,' ',new Base[]{
							new Normal('E',null,0,' ',new Base[]{
								new Normal('R',null,0,' ',new Base[]{
									new NormalLoop(' ',null,0,(char)VK.VK_RETURN,null),
									new Normal('}',null,0,(char)VK.VK_RETURN,null),
									new Normal(null,ParseException,0,' ',null)
								}),
								new Normal(null,ParseException,0,' ',null)
							}),
							new Normal(null,ParseException,0,' ',null)
						}),
						new Normal(null,ParseException,0,' ',null)
					}),
					new Normal('S',null,0,' ',new Base[]{
						new Normal('C',null,0,' ',new Base[]{
							new NormalLoop(' ',null,0,(char)VK.VK_ESCAPE,null),
							new Normal('}',null,0,(char)VK.VK_ESCAPE,null),
							new Normal(null,ParseException,0,' ',null)
						}),
						new Normal(null,ParseException,0,' ',null)
					}),
					new NormalLoop(' ',null,KeyboardFlag.Unicode,'E',null),
					new Normal('}',null,KeyboardFlag.Unicode,'E',null),
					new Normal(null,ParseException,0,' ',null)
				}),
				new Normal('F',null,0,' ',new Base[]{
					new Normal('1',null,0,' ',new Base[]{
						new Normal('0',null,0,' ',new Base[]{
							new NormalLoop(' ',null,0,(char)VK.VK_F10,null),
							new Normal('}',null,0,(char)VK.VK_F10,null),
							new Normal(null,ParseException,0,' ',null)
						}),
						new Normal('1',null,0,' ',new Base[]{
							new NormalLoop(' ',null,0,(char)VK.VK_F11,null),
							new Normal('}',null,0,(char)VK.VK_F11,null),
							new Normal(null,ParseException,0,' ',null)
						}),
						new Normal('2',null,0,' ',new Base[]{
							new NormalLoop(' ',null,0,(char)VK.VK_F12,null),
							new Normal('}',null,0,(char)VK.VK_F12,null),
							new Normal(null,ParseException,0,' ',null)
						}),
						new Normal('3',null,0,' ',new Base[]{
							new NormalLoop(' ',null,0,(char)VK.VK_F13,null),
							new Normal('}',null,0,(char)VK.VK_F13,null),
							new Normal(null,ParseException,0,' ',null)
						}),
						new Normal('4',null,0,' ',new Base[]{
							new NormalLoop(' ',null,0,(char)VK.VK_F14,null),
							new Normal('}',null,0,(char)VK.VK_F14,null),
							new Normal(null,ParseException,0,' ',null)
						}),
						new Normal('5',null,0,' ',new Base[]{
							new NormalLoop(' ',null,0,(char)VK.VK_F15,null),
							new Normal('}',null,0,(char)VK.VK_F15,null),
							new Normal(null,ParseException,0,' ',null)
						}),
						new Normal('6',null,0,' ',new Base[]{
							new NormalLoop(' ',null,0,(char)VK.VK_F16,null),
							new Normal('}',null,0,(char)VK.VK_F16,null),
							new Normal(null,ParseException,0,' ',null)
						}),
						new NormalLoop(' ',null,0,(char)VK.VK_F1,null),
						new Normal('}',null,0,(char)VK.VK_F1,null),
						new Normal(null,ParseException,0,' ',null)
					}),
					new Normal('2',null,0,' ',new Base[]{
						new NormalLoop(' ',null,0,(char)VK.VK_F2,null),
						new Normal('}',null,0,(char)VK.VK_F2,null),
						new Normal(null,ParseException,0,' ',null)
					}),
					new Normal('3',null,0,' ',new Base[]{
						new NormalLoop(' ',null,0,(char)VK.VK_F3,null),
						new Normal('}',null,0,(char)VK.VK_F3,null),
						new Normal(null,ParseException,0,' ',null)
					}),
					new Normal('4',null,0,' ',new Base[]{
						new NormalLoop(' ',null,0,(char)VK.VK_F4,null),
						new Normal('}',null,0,(char)VK.VK_F4,null),
						new Normal(null,ParseException,0,' ',null)
					}),
					new Normal('5',null,0,' ',new Base[]{
						new NormalLoop(' ',null,0,(char)VK.VK_F5,null),
						new Normal('}',null,0,(char)VK.VK_F5,null),
						new Normal(null,ParseException,0,' ',null)
					}),
					new Normal('6',null,0,' ',new Base[]{
						new NormalLoop(' ',null,0,(char)VK.VK_F6,null),
						new Normal('}',null,0,(char)VK.VK_F6,null),
						new Normal(null,ParseException,0,' ',null)
					}),
					new Normal('7',null,0,' ',new Base[]{
						new NormalLoop(' ',null,0,(char)VK.VK_F7,null),
						new Normal('}',null,0,(char)VK.VK_F7,null),
						new Normal(null,ParseException,0,' ',null)
					}),
					new Normal('8',null,0,' ',new Base[]{
						new NormalLoop(' ',null,0,(char)VK.VK_F8,null),
						new Normal('}',null,0,(char)VK.VK_F8,null),
						new Normal(null,ParseException,0,' ',null)
					}),
					new Normal('9',null,0,' ',new Base[]{
						new NormalLoop(' ',null,0,(char)VK.VK_F9,null),
						new Normal('}',null,0,(char)VK.VK_F9,null),
						new Normal(null,ParseException,0,' ',null)
					}),
					new NormalLoop(' ',null,KeyboardFlag.Unicode,'F',null),
					new Normal('}',null,KeyboardFlag.Unicode,'F',null),
					new Normal(null,ParseException,0,' ',null)
				}),
				new Normal('H',null,0,' ',new Base[]{
				new Normal('E',null,0,' ',new Base[]{
					new Normal('L',null,0,' ',new Base[]{
						new Normal('P',null,0,' ',new Base[]{
							new NormalLoop(' ',null,0,(char)VK.VK_HELP,null) ,
							new Normal('}',null,0,(char)VK.VK_HELP,null),
							new Normal(null,ParseException,0,' ',null)
						}),
						new Normal(null,ParseException,0,' ',null)
					}),
					new Normal(null,ParseException,0,' ',null)
					}),
					new Normal('O',null,0,' ',new Base[]{
						new Normal('M',null,0,' ',new Base[]{
							new Normal('E',null,0,' ',new Base[]{
								new NormalLoop(' ',null,0,(char)VK.VK_HOME,null),
								new Normal('}',null,0,(char)VK.VK_HOME,null),
								new Normal(null,ParseException,0,' ',null)
							}),
							new Normal(null,ParseException,0,' ',null)
						}),
						new Normal(null,ParseException,0,' ',null)
					}),
					new NormalLoop(' ',null,KeyboardFlag.Unicode,'F',null),
					new Normal('}',null,KeyboardFlag.Unicode,'F',null),
					new Normal(null,ParseException,0,' ',null)
				}),
				new Normal('I',null,0,' ',new Base[]{
					new Normal('N',null,0,' ',new Base[]{
						new Normal('S',null,0,' ',new Base[]{
							new Normal('E',null,0,' ',new Base[]{
								new Normal('R',null,0,' ',new Base[]{
									new Normal('T',null,0,' ',new Base[]{
										new NormalLoop(' ',null,0,(char)VK.VK_INSERT,null),
										new Normal('}',null,0,(char)VK.VK_INSERT,null),
										new Normal(null,ParseException,0,' ',null)
									}),
									new Normal(null,ParseException,0,' ',null)
								}),
								new Normal(null,ParseException,0,' ',null)
							}),
							new NormalLoop(' ',null,0,(char)VK.VK_INSERT,null),
							new Normal('}',null,0,(char)VK.VK_INSERT,null),
							new Normal(null,ParseException,0,' ',null)
						}),
						new Normal(null,ParseException,0,' ',null)
					}),
					new NormalLoop(' ',null,KeyboardFlag.Unicode,'I',null),
					new Normal('}',null,KeyboardFlag.Unicode,'I',null),
					new Normal(null,ParseException,0,' ',null)
				}),
				new Normal('L',null,0,' ',new Base[]{
					new Normal('E',null,0,' ',new Base[]{
						new Normal('F',null,0,' ',new Base[]{
							new Normal('T',null,0,' ',new Base[]{
								new NormalLoop(' ',null,0,(char)VK.VK_LEFT,null),
								new Normal('}',null,0,(char)VK.VK_LEFT,null),
								new Normal(null,ParseException,0,' ',null)
							}),
							new Normal(null,ParseException,0,' ',null)
						}),
						new Normal(null,ParseException,0,' ',null)
					}),
					new NormalLoop(' ',null,KeyboardFlag.Unicode,'L',null),
					new Normal('}',null,KeyboardFlag.Unicode,'L',null),
					new Normal(null,ParseException,0,' ',null)
				}),
				new Normal('M',null,0,' ',new Base[]{
					new Normal('U',null,0,' ',new Base[]{
						new Normal('L',null,0,' ',new Base[]{
							new Normal('T',null,0,' ',new Base[]{
								new Normal('I',null,0,' ',new Base[]{
									new Normal('P',null,0,' ',new Base[]{
										new Normal('L',null,0,' ',new Base[]{
											new Normal('Y',null,0,' ',new Base[]{
												new NormalLoop(' ',null,0,(char)VK.VK_MULTIPLY,null),
												new Normal('}',null,0,(char)VK.VK_MULTIPLY,null),
												new Normal(null,ParseException,0,' ',null)
											}),
											new Normal(null,ParseException,0,' ',null)
										}),
										new Normal(null,ParseException,0,' ',null)
									}),
									new Normal(null,ParseException,0,' ',null)
								}),
								new Normal(null,ParseException,0,' ',null)
							}),
							new Normal(null,ParseException,0,' ',null)
						}),
						new Normal(null,ParseException,0,' ',null)
					}),
					new NormalLoop(' ',null,KeyboardFlag.Unicode,'M',null),
					new Normal('}',null,KeyboardFlag.Unicode,'M',null),
					new Normal(null,ParseException,0,' ',null)
				}),
				new Normal('N',null,0,' ',new Base[]{
					new Normal('U',null,0,' ',new Base[]{
						new Normal('M',null,0,' ',new Base[]{
							new Normal('L',null,0,' ',new Base[]{
								new Normal('O',null,0,' ',new Base[]{
									new Normal('C',null,0,' ',new Base[]{
										new Normal('K',null,0,' ',new Base[]{
											new NormalLoop(' ',null,0,(char)VK.VK_NUMLOCK,null),
											new Normal('}',null,0,(char)VK.VK_NUMLOCK,null),
											new Normal(null,ParseException,0,' ',null)
										}),
										new Normal(null,ParseException,0,' ',null)
									}),
									new Normal(null,ParseException,0,' ',null)
								}),
								new Normal(null,ParseException,0,' ',null)
							}),
							new Normal(null,ParseException,0,' ',null)
						}),
						new Normal(null,ParseException,0,' ',null)
					}),
					new NormalLoop(' ',null,KeyboardFlag.Unicode,'N',null),
					new Normal('}',null,KeyboardFlag.Unicode,'N',null),
					new Normal(null,ParseException,0,' ',null)
				}),
				new Normal('P',null,0,' ',new Base[]{
					new Normal('G',null,0,' ',new Base[]{
						new Normal('D',null,0,' ',new Base[]{
							new Normal('N',null,0,' ',new Base[]{
								new NormalLoop(' ',null,0,(char)VK.VK_NEXT,null),
								new Normal('}',null,0,(char)VK.VK_NEXT,null),
								new Normal(null,ParseException,0,' ',null)
							}),
						new Normal(null,ParseException,0,' ',null)
						}),
						new Normal('U',null,0,' ',new Base[]{
							new Normal('P',null,0,' ',new Base[]{
								new NormalLoop(' ',null,0,(char)VK.VK_PRIOR,null),
								new Normal('}',null,0,(char)VK.VK_PRIOR,null),
								new Normal(null,ParseException,0,' ',null)
							}),
							new Normal(null,ParseException,0,' ',null)
						}),
						new Normal(null,ParseException,0,' ',null)
					}),
					new Normal('R',null,0,' ',new Base[]{
						new Normal('T',null,0,' ',new Base[]{
							new Normal('S',null,0,' ',new Base[]{
								new Normal('C',null,0,' ',new Base[]{
									new NormalLoop(' ',null,0,(char)VK.VK_SNAPSHOT,null),
									new Normal('}',null,0,(char)VK.VK_SNAPSHOT,null),
									new Normal(null,ParseException,0,' ',null)
								}),
								new Normal(null,ParseException,0,' ',null)
							}),
							new Normal(null,ParseException,0,' ',null)
						}),
						new Normal(null,ParseException,0,' ',null)
					}),
					new NormalLoop(' ',null,KeyboardFlag.Unicode,'P',null),
					new Normal('}',null,KeyboardFlag.Unicode,'P',null),
					new Normal(null,ParseException,0,' ',null)
				}),
				new Normal('R',null,0,' ',new Base[]{
					new Normal('I',null,0,' ',new Base[]{
						new Normal('G',null,0,' ',new Base[]{
							new Normal('H',null,0,' ',new Base[]{
								new Normal('T',null,0,' ',new Base[]{
									new NormalLoop(' ',null,0,(char)VK.VK_RIGHT,null),
									new Normal('}',null,0,(char)VK.VK_RIGHT,null),
									new Normal(null,ParseException,0,' ',null)
								}),
								new Normal(null,ParseException,0,' ',null)
							}),
							new Normal(null,ParseException,0,' ',null)
						}),
						new Normal(null,ParseException,0,' ',null)
					}),
					new NormalLoop(' ',null,KeyboardFlag.Unicode,'R',null),
					new Normal('}',null,KeyboardFlag.Unicode,'R',null),
					new Normal(null,ParseException,0,' ',null)
				}),
				new Normal('S',null,0,' ',new Base[]{
					new Normal('C',null,0,' ',new Base[]{
						new Normal('R',null,0,' ',new Base[]{
							new Normal('O',null,0,' ',new Base[]{
								new Normal('L',null,0,' ',new Base[]{
									new Normal('L',null,0,' ',new Base[]{
										new Normal('L',null,0,' ',new Base[]{
											new Normal('O',null,0,' ',new Base[]{
												new Normal('C',null,0,' ',new Base[]{
													new Normal('K',null,0,' ',new Base[]{
														new NormalLoop(' ',null,0,(char)VK.VK_SCROLL,null),
														new Normal('}',null,0,(char)VK.VK_SCROLL,null),
														new Normal(null,ParseException,0,' ',null)
													}),
													new Normal(null,ParseException,0,' ',null)
												}),
												new Normal(null,ParseException,0,' ',null)
											}),
											new Normal(null,ParseException,0,' ',null)
										}),
										new Normal(null,ParseException,0,' ',null)
									}),
									new Normal(null,ParseException,0,' ',null)
								}),
								new Normal(null,ParseException,0,' ',null)
							}),
							new Normal(null,ParseException,0,' ',null)
						}),
						new Normal(null,ParseException,0,' ',null)
					}),
					new Normal('U',null,0,' ',new Base[]{
						new Normal('B',null,0,' ',new Base[]{
							new Normal('T',null,0,' ',new Base[]{
								new Normal('R',null,0,' ',new Base[]{
									new Normal('A',null,0,' ',new Base[]{
										new Normal('C',null,0,' ',new Base[]{
											new Normal('T',null,0,' ',new Base[]{
												new NormalLoop(' ',null,0,(char)VK.VK_SUBTRACT,null),
												new Normal('}',null,0,(char)VK.VK_SUBTRACT,null),
												new Normal(null,ParseException,0,' ',null)
											}),
											new Normal(null,ParseException,0,' ',null)
										}),
										new Normal(null,ParseException,0,' ',null)
									}),
									new Normal(null,ParseException,0,' ',null)
								}),
								new Normal(null,ParseException,0,' ',null)
							}),
							new Normal(null,ParseException,0,' ',null)
						}),
						new Normal(null,ParseException,0,' ',null)
					}),
					new NormalLoop(' ',null,KeyboardFlag.Unicode,'S',null),
					new Normal('}',null,KeyboardFlag.Unicode,'S',null),
					new Normal(null,ParseException,0,' ',null)
				}),
				new Normal('T',null,0,' ',new Base[]{
					new Normal('A',null,0,' ',new Base[]{
						new Normal('B',null,0,' ',new Base[]{
							new NormalLoop(' ',null,0,(char)VK.VK_TAB,null),
							new Normal('}',null,0,(char)VK.VK_TAB,null),
							new Normal(null,ParseException,0,' ',null)
						}),
						new Normal(null,ParseException,0,' ',null)
					}),
					new NormalLoop(' ',null,KeyboardFlag.Unicode,'T',null),
					new Normal('}',null,KeyboardFlag.Unicode,'T',null),
					new Normal(null,ParseException,0,' ',null)
				}),
				new Normal('U',null,0,' ',new Base[]{
					new Normal('P',null,0,' ',new Base[]{
						new NormalLoop(' ',null,0,(char)VK.VK_UP,null),
						new Normal('}',null,0,(char)VK.VK_UP,null),
						new Normal(null,ParseException,0,' ',null)
					}),
					new NormalLoop(' ',null,KeyboardFlag.Unicode,'U',null),
					new Normal('}',null,KeyboardFlag.Unicode,'U',null),
					new Normal(null,ParseException,0,' ',null)
				}),
				new Normal('W',null,0,' ',new Base[]{
					new Normal('S',null,0,' ',new Base[]{
						new Normal('.',null,0,' ',new Base[]{
							new Normal('T',null,0,' ',new Base[]{
								new Normal('H',null,0,' ',new Base[]{
									new Normal('E',null,0,' ',new Base[]{
										new Normal('I',null,0,' ',new Base[]{
											new Normal('A',null,0,' ',new Base[]{
												new Normal('.',null,0,' ',new Base[]{
													new Normal('V',null,0,' ',new Base[]{
														new Normal('K',null,0,' ',new Base[]{
															new Normal('_',null,0,' ',new Base[]{
																new Normal('0',null,0,' ',new Base[]{
																	new NormalLoop(' ',null,0,(char)VK.VK_0,null),
																	new Normal('}',null,0,(char)VK.VK_0,null),
																	new Normal('.',null,0,' ',new Base[]{
																		new Normal('C',null,0,' ',new Base[]{
																			new Normal('O',null,0,' ',new Base[]{
																				new Normal('M',null,0,' ',new Base[]{
																					new Normal('B',null,0,' ',new Base[]{
																						new Normal('I',null,0,' ',new Base[]{
																							new CombinationLoop(' ',null,0,(char)VK.VK_0,null),
																							new Combination('}',null,0,(char)VK.VK_0,null),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal('x',null,0,' ',new Base[]{
																		new Normal('0',null,0,' ',new Base[]{
																			new Normal('0',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x00,null),
																				new Normal('}',null,0,(char)VK.VK_0x00,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x00,null),
																										new Combination('}',null,0,(char)VK.VK_0x00,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('1',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x01,null),
																				new Normal('}',null,0,(char)VK.VK_0x01,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x01,null),
																										new Combination('}',null,0,(char)VK.VK_0x01,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('2',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x02,null),
																				new Normal('}',null,0,(char)VK.VK_0x02,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x02,null),
																										new Combination('}',null,0,(char)VK.VK_0x02,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('3',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x03,null),
																				new Normal('}',null,0,(char)VK.VK_0x03,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x03,null),
																										new Combination('}',null,0,(char)VK.VK_0x03,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('4',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x04,null),
																				new Normal('}',null,0,(char)VK.VK_0x04,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x04,null),
																										new Combination('}',null,0,(char)VK.VK_0x04,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('5',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x05,null),
																				new Normal('}',null,0,(char)VK.VK_0x05,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x05,null),
																										new Combination('}',null,0,(char)VK.VK_0x05,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('6',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x06,null),
																				new Normal('}',null,0,(char)VK.VK_0x06,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x06,null),
																										new Combination('}',null,0,(char)VK.VK_0x06,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('7',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x07,null),
																				new Normal('}',null,0,(char)VK.VK_0x07,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x07,null),
																										new Combination('}',null,0,(char)VK.VK_0x07,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('8',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x08,null),
																				new Normal('}',null,0,(char)VK.VK_0x08,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x08,null),
																										new Combination('}',null,0,(char)VK.VK_0x08,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('9',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x09,null),
																				new Normal('}',null,0,(char)VK.VK_0x09,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x09,null),
																										new Combination('}',null,0,(char)VK.VK_0x09,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('A',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x0A,null),
																				new Normal('}',null,0,(char)VK.VK_0x0A,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x0A,null),
																										new Combination('}',null,0,(char)VK.VK_0x0A,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('B',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x0B,null),
																				new Normal('}',null,0,(char)VK.VK_0x0B,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x0B,null),
																										new Combination('}',null,0,(char)VK.VK_0x0B,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('C',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x0C,null),
																				new Normal('}',null,0,(char)VK.VK_0x0C,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x0C,null),
																										new Combination('}',null,0,(char)VK.VK_0x0C,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('D',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x0D,null),
																				new Normal('}',null,0,(char)VK.VK_0x0D,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x0D,null),
																										new Combination('}',null,0,(char)VK.VK_0x0D,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('E',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x0E,null),
																				new Normal('}',null,0,(char)VK.VK_0x0E,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x0E,null),
																										new Combination('}',null,0,(char)VK.VK_0x0E,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('F',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x0F,null),
																				new Normal('}',null,0,(char)VK.VK_0x0F,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x0F,null),
																										new Combination('}',null,0,(char)VK.VK_0x0F,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal('1',null,0,' ',new Base[]{
																			new Normal('0',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x10,null),
																				new Normal('}',null,0,(char)VK.VK_0x10,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x10,null),
																										new Combination('}',null,0,(char)VK.VK_0x10,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('1',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x11,null),
																				new Normal('}',null,0,(char)VK.VK_0x11,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x11,null),
																										new Combination('}',null,0,(char)VK.VK_0x11,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('2',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x12,null),
																				new Normal('}',null,0,(char)VK.VK_0x12,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x12,null),
																										new Combination('}',null,0,(char)VK.VK_0x12,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('3',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x13,null),
																				new Normal('}',null,0,(char)VK.VK_0x13,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x13,null),
																										new Combination('}',null,0,(char)VK.VK_0x13,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('4',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x14,null),
																				new Normal('}',null,0,(char)VK.VK_0x14,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x14,null),
																										new Combination('}',null,0,(char)VK.VK_0x14,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('5',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x15,null),
																				new Normal('}',null,0,(char)VK.VK_0x15,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x15,null),
																										new Combination('}',null,0,(char)VK.VK_0x15,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('6',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x16,null),
																				new Normal('}',null,0,(char)VK.VK_0x16,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x16,null),
																										new Combination('}',null,0,(char)VK.VK_0x16,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('7',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x17,null),
																				new Normal('}',null,0,(char)VK.VK_0x17,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x17,null),
																										new Combination('}',null,0,(char)VK.VK_0x17,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('8',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x18,null),
																				new Normal('}',null,0,(char)VK.VK_0x18,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x18,null),
																										new Combination('}',null,0,(char)VK.VK_0x18,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('9',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x19,null),
																				new Normal('}',null,0,(char)VK.VK_0x19,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x19,null),
																										new Combination('}',null,0,(char)VK.VK_0x19,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('A',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x1A,null),
																				new Normal('}',null,0,(char)VK.VK_0x1A,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x1A,null),
																										new Combination('}',null,0,(char)VK.VK_0x1A,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('B',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x1B,null),
																				new Normal('}',null,0,(char)VK.VK_0x1B,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x1B,null),
																										new Combination('}',null,0,(char)VK.VK_0x1B,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('C',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x1C,null),
																				new Normal('}',null,0,(char)VK.VK_0x1C,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x1C,null),
																										new Combination('}',null,0,(char)VK.VK_0x1C,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('D',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x1D,null),
																				new Normal('}',null,0,(char)VK.VK_0x1D,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x1D,null),
																										new Combination('}',null,0,(char)VK.VK_0x1D,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('E',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x1E,null),
																				new Normal('}',null,0,(char)VK.VK_0x1E,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x1E,null),
																										new Combination('}',null,0,(char)VK.VK_0x1E,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('F',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x1F,null),
																				new Normal('}',null,0,(char)VK.VK_0x1F,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x1F,null),
																										new Combination('}',null,0,(char)VK.VK_0x1F,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal('2',null,0,' ',new Base[]{
																			new Normal('0',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x20,null),
																				new Normal('}',null,0,(char)VK.VK_0x20,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x20,null),
																										new Combination('}',null,0,(char)VK.VK_0x20,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('1',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x21,null),
																				new Normal('}',null,0,(char)VK.VK_0x21,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x21,null),
																										new Combination('}',null,0,(char)VK.VK_0x21,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('2',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x22,null),
																				new Normal('}',null,0,(char)VK.VK_0x22,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x22,null),
																										new Combination('}',null,0,(char)VK.VK_0x22,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('3',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x23,null),
																				new Normal('}',null,0,(char)VK.VK_0x23,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x23,null),
																										new Combination('}',null,0,(char)VK.VK_0x23,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('4',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x24,null),
																				new Normal('}',null,0,(char)VK.VK_0x24,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x24,null),
																										new Combination('}',null,0,(char)VK.VK_0x24,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('5',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x25,null),
																				new Normal('}',null,0,(char)VK.VK_0x25,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x25,null),
																										new Combination('}',null,0,(char)VK.VK_0x25,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('6',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x26,null),
																				new Normal('}',null,0,(char)VK.VK_0x26,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x26,null),
																										new Combination('}',null,0,(char)VK.VK_0x26,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('7',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x27,null),
																				new Normal('}',null,0,(char)VK.VK_0x27,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x27,null),
																										new Combination('}',null,0,(char)VK.VK_0x27,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('8',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x28,null),
																				new Normal('}',null,0,(char)VK.VK_0x28,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x28,null),
																										new Combination('}',null,0,(char)VK.VK_0x28,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('9',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x29,null),
																				new Normal('}',null,0,(char)VK.VK_0x29,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x29,null),
																										new Combination('}',null,0,(char)VK.VK_0x29,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('A',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x2A,null),
																				new Normal('}',null,0,(char)VK.VK_0x2A,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x2A,null),
																										new Combination('}',null,0,(char)VK.VK_0x2A,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('B',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x2B,null),
																				new Normal('}',null,0,(char)VK.VK_0x2B,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x2B,null),
																										new Combination('}',null,0,(char)VK.VK_0x2B,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('C',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x2C,null),
																				new Normal('}',null,0,(char)VK.VK_0x2C,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x2C,null),
																										new Combination('}',null,0,(char)VK.VK_0x2C,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('D',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x2D,null),
																				new Normal('}',null,0,(char)VK.VK_0x2D,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x2D,null),
																										new Combination('}',null,0,(char)VK.VK_0x2D,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('E',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x2E,null),
																				new Normal('}',null,0,(char)VK.VK_0x2E,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x2E,null),
																										new Combination('}',null,0,(char)VK.VK_0x2E,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('F',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x2F,null),
																				new Normal('}',null,0,(char)VK.VK_0x2F,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x2F,null),
																										new Combination('}',null,0,(char)VK.VK_0x2F,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal('3',null,0,' ',new Base[]{
																			new Normal('0',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x30,null),
																				new Normal('}',null,0,(char)VK.VK_0x30,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x30,null),
																										new Combination('}',null,0,(char)VK.VK_0x30,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('1',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x31,null),
																				new Normal('}',null,0,(char)VK.VK_0x31,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x31,null),
																										new Combination('}',null,0,(char)VK.VK_0x31,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('2',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x32,null),
																				new Normal('}',null,0,(char)VK.VK_0x32,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x32,null),
																										new Combination('}',null,0,(char)VK.VK_0x32,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('3',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x33,null),
																				new Normal('}',null,0,(char)VK.VK_0x33,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x33,null),
																										new Combination('}',null,0,(char)VK.VK_0x33,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('4',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x34,null),
																				new Normal('}',null,0,(char)VK.VK_0x34,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x34,null),
																										new Combination('}',null,0,(char)VK.VK_0x34,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('5',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x35,null),
																				new Normal('}',null,0,(char)VK.VK_0x35,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x35,null),
																										new Combination('}',null,0,(char)VK.VK_0x35,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('6',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x36,null),
																				new Normal('}',null,0,(char)VK.VK_0x36,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x36,null),
																										new Combination('}',null,0,(char)VK.VK_0x36,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('7',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x37,null),
																				new Normal('}',null,0,(char)VK.VK_0x37,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x37,null),
																										new Combination('}',null,0,(char)VK.VK_0x37,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('8',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x38,null),
																				new Normal('}',null,0,(char)VK.VK_0x38,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x38,null),
																										new Combination('}',null,0,(char)VK.VK_0x38,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('9',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x39,null),
																				new Normal('}',null,0,(char)VK.VK_0x39,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x39,null),
																										new Combination('}',null,0,(char)VK.VK_0x39,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('A',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x3A,null),
																				new Normal('}',null,0,(char)VK.VK_0x3A,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x3A,null),
																										new Combination('}',null,0,(char)VK.VK_0x3A,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('B',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x3B,null),
																				new Normal('}',null,0,(char)VK.VK_0x3B,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x3B,null),
																										new Combination('}',null,0,(char)VK.VK_0x3B,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('C',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x3C,null),
																				new Normal('}',null,0,(char)VK.VK_0x3C,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x3C,null),
																										new Combination('}',null,0,(char)VK.VK_0x3C,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('D',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x3D,null),
																				new Normal('}',null,0,(char)VK.VK_0x3D,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x3D,null),
																										new Combination('}',null,0,(char)VK.VK_0x3D,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('E',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x3E,null),
																				new Normal('}',null,0,(char)VK.VK_0x3E,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x3E,null),
																										new Combination('}',null,0,(char)VK.VK_0x3E,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('F',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x3F,null),
																				new Normal('}',null,0,(char)VK.VK_0x3F,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x3F,null),
																										new Combination('}',null,0,(char)VK.VK_0x3F,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal('4',null,0,' ',new Base[]{
																			new Normal('0',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x40,null),
																				new Normal('}',null,0,(char)VK.VK_0x40,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x40,null),
																										new Combination('}',null,0,(char)VK.VK_0x40,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('1',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x41,null),
																				new Normal('}',null,0,(char)VK.VK_0x41,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x41,null),
																										new Combination('}',null,0,(char)VK.VK_0x41,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('2',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x42,null),
																				new Normal('}',null,0,(char)VK.VK_0x42,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x42,null),
																										new Combination('}',null,0,(char)VK.VK_0x42,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('3',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x43,null),
																				new Normal('}',null,0,(char)VK.VK_0x43,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x43,null),
																										new Combination('}',null,0,(char)VK.VK_0x43,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('4',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x44,null),
																				new Normal('}',null,0,(char)VK.VK_0x44,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x44,null),
																										new Combination('}',null,0,(char)VK.VK_0x44,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('5',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x45,null),
																				new Normal('}',null,0,(char)VK.VK_0x45,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x45,null),
																										new Combination('}',null,0,(char)VK.VK_0x45,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('6',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x46,null),
																				new Normal('}',null,0,(char)VK.VK_0x46,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x46,null),
																										new Combination('}',null,0,(char)VK.VK_0x46,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('7',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x47,null),
																				new Normal('}',null,0,(char)VK.VK_0x47,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x47,null),
																										new Combination('}',null,0,(char)VK.VK_0x47,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('8',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x48,null),
																				new Normal('}',null,0,(char)VK.VK_0x48,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x48,null),
																										new Combination('}',null,0,(char)VK.VK_0x48,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('9',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x49,null),
																				new Normal('}',null,0,(char)VK.VK_0x49,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x49,null),
																										new Combination('}',null,0,(char)VK.VK_0x49,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('A',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x4A,null),
																				new Normal('}',null,0,(char)VK.VK_0x4A,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x4A,null),
																										new Combination('}',null,0,(char)VK.VK_0x4A,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('B',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x4B,null),
																				new Normal('}',null,0,(char)VK.VK_0x4B,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x4B,null),
																										new Combination('}',null,0,(char)VK.VK_0x4B,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('C',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x4C,null),
																				new Normal('}',null,0,(char)VK.VK_0x4C,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x4C,null),
																										new Combination('}',null,0,(char)VK.VK_0x4C,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('D',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x4D,null),
																				new Normal('}',null,0,(char)VK.VK_0x4D,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x4D,null),
																										new Combination('}',null,0,(char)VK.VK_0x4D,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('E',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x4E,null),
																				new Normal('}',null,0,(char)VK.VK_0x4E,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x4E,null),
																										new Combination('}',null,0,(char)VK.VK_0x4E,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('F',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x4F,null),
																				new Normal('}',null,0,(char)VK.VK_0x4F,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x4F,null),
																										new Combination('}',null,0,(char)VK.VK_0x4F,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal('5',null,0,' ',new Base[]{
																			new Normal('0',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x50,null),
																				new Normal('}',null,0,(char)VK.VK_0x50,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x50,null),
																										new Combination('}',null,0,(char)VK.VK_0x50,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('1',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x51,null),
																				new Normal('}',null,0,(char)VK.VK_0x51,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x51,null),
																										new Combination('}',null,0,(char)VK.VK_0x51,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('2',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x52,null),
																				new Normal('}',null,0,(char)VK.VK_0x52,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x52,null),
																										new Combination('}',null,0,(char)VK.VK_0x52,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('3',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x53,null),
																				new Normal('}',null,0,(char)VK.VK_0x53,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x53,null),
																										new Combination('}',null,0,(char)VK.VK_0x53,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('4',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x54,null),
																				new Normal('}',null,0,(char)VK.VK_0x54,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x54,null),
																										new Combination('}',null,0,(char)VK.VK_0x54,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('5',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x55,null),
																				new Normal('}',null,0,(char)VK.VK_0x55,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x55,null),
																										new Combination('}',null,0,(char)VK.VK_0x55,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('6',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x56,null),
																				new Normal('}',null,0,(char)VK.VK_0x56,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x56,null),
																										new Combination('}',null,0,(char)VK.VK_0x56,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('7',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x57,null),
																				new Normal('}',null,0,(char)VK.VK_0x57,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x57,null),
																										new Combination('}',null,0,(char)VK.VK_0x57,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('8',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x58,null),
																				new Normal('}',null,0,(char)VK.VK_0x58,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x58,null),
																										new Combination('}',null,0,(char)VK.VK_0x58,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('9',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x59,null),
																				new Normal('}',null,0,(char)VK.VK_0x59,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x59,null),
																										new Combination('}',null,0,(char)VK.VK_0x59,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('A',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x5A,null),
																				new Normal('}',null,0,(char)VK.VK_0x5A,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x5A,null),
																										new Combination('}',null,0,(char)VK.VK_0x5A,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('B',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x5B,null),
																				new Normal('}',null,0,(char)VK.VK_0x5B,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x5B,null),
																										new Combination('}',null,0,(char)VK.VK_0x5B,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('C',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x5C,null),
																				new Normal('}',null,0,(char)VK.VK_0x5C,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x5C,null),
																										new Combination('}',null,0,(char)VK.VK_0x5C,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('D',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x5D,null),
																				new Normal('}',null,0,(char)VK.VK_0x5D,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x5D,null),
																										new Combination('}',null,0,(char)VK.VK_0x5D,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('E',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x5E,null),
																				new Normal('}',null,0,(char)VK.VK_0x5E,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x5E,null),
																										new Combination('}',null,0,(char)VK.VK_0x5E,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('F',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x5F,null),
																				new Normal('}',null,0,(char)VK.VK_0x5F,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x5F,null),
																										new Combination('}',null,0,(char)VK.VK_0x5F,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal('6',null,0,' ',new Base[]{
																			new Normal('0',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x60,null),
																				new Normal('}',null,0,(char)VK.VK_0x60,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x60,null),
																										new Combination('}',null,0,(char)VK.VK_0x60,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('1',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x61,null),
																				new Normal('}',null,0,(char)VK.VK_0x61,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x61,null),
																										new Combination('}',null,0,(char)VK.VK_0x61,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('2',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x62,null),
																				new Normal('}',null,0,(char)VK.VK_0x62,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x62,null),
																										new Combination('}',null,0,(char)VK.VK_0x62,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('3',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x63,null),
																				new Normal('}',null,0,(char)VK.VK_0x63,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x63,null),
																										new Combination('}',null,0,(char)VK.VK_0x63,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('4',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x64,null),
																				new Normal('}',null,0,(char)VK.VK_0x64,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x64,null),
																										new Combination('}',null,0,(char)VK.VK_0x64,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('5',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x65,null),
																				new Normal('}',null,0,(char)VK.VK_0x65,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x65,null),
																										new Combination('}',null,0,(char)VK.VK_0x65,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('6',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x66,null),
																				new Normal('}',null,0,(char)VK.VK_0x66,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x66,null),
																										new Combination('}',null,0,(char)VK.VK_0x66,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('7',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x67,null),
																				new Normal('}',null,0,(char)VK.VK_0x67,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x67,null),
																										new Combination('}',null,0,(char)VK.VK_0x67,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('8',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x68,null),
																				new Normal('}',null,0,(char)VK.VK_0x68,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x68,null),
																										new Combination('}',null,0,(char)VK.VK_0x68,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('9',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x69,null),
																				new Normal('}',null,0,(char)VK.VK_0x69,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x69,null),
																										new Combination('}',null,0,(char)VK.VK_0x69,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('A',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x6A,null),
																				new Normal('}',null,0,(char)VK.VK_0x6A,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x6A,null),
																										new Combination('}',null,0,(char)VK.VK_0x6A,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('B',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x6B,null),
																				new Normal('}',null,0,(char)VK.VK_0x6B,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x6B,null),
																										new Combination('}',null,0,(char)VK.VK_0x6B,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('C',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x6C,null),
																				new Normal('}',null,0,(char)VK.VK_0x6C,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x6C,null),
																										new Combination('}',null,0,(char)VK.VK_0x6C,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('D',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x6D,null),
																				new Normal('}',null,0,(char)VK.VK_0x6D,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x6D,null),
																										new Combination('}',null,0,(char)VK.VK_0x6D,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('E',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x6E,null),
																				new Normal('}',null,0,(char)VK.VK_0x6E,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x6E,null),
																										new Combination('}',null,0,(char)VK.VK_0x6E,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('F',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x6F,null),
																				new Normal('}',null,0,(char)VK.VK_0x6F,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x6F,null),
																										new Combination('}',null,0,(char)VK.VK_0x6F,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal('7',null,0,' ',new Base[]{
																			new Normal('0',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x70,null),
																				new Normal('}',null,0,(char)VK.VK_0x70,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x70,null),
																										new Combination('}',null,0,(char)VK.VK_0x70,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('1',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x71,null),
																				new Normal('}',null,0,(char)VK.VK_0x71,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x71,null),
																										new Combination('}',null,0,(char)VK.VK_0x71,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('2',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x72,null),
																				new Normal('}',null,0,(char)VK.VK_0x72,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x72,null),
																										new Combination('}',null,0,(char)VK.VK_0x72,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('3',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x73,null),
																				new Normal('}',null,0,(char)VK.VK_0x73,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x73,null),
																										new Combination('}',null,0,(char)VK.VK_0x73,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('4',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x74,null),
																				new Normal('}',null,0,(char)VK.VK_0x74,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x74,null),
																										new Combination('}',null,0,(char)VK.VK_0x74,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('5',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x75,null),
																				new Normal('}',null,0,(char)VK.VK_0x75,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x75,null),
																										new Combination('}',null,0,(char)VK.VK_0x75,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('6',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x76,null),
																				new Normal('}',null,0,(char)VK.VK_0x76,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x76,null),
																										new Combination('}',null,0,(char)VK.VK_0x76,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('7',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x77,null),
																				new Normal('}',null,0,(char)VK.VK_0x77,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x77,null),
																										new Combination('}',null,0,(char)VK.VK_0x77,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('8',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x78,null),
																				new Normal('}',null,0,(char)VK.VK_0x78,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x78,null),
																										new Combination('}',null,0,(char)VK.VK_0x78,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('9',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x79,null),
																				new Normal('}',null,0,(char)VK.VK_0x79,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x79,null),
																										new Combination('}',null,0,(char)VK.VK_0x79,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('A',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x7A,null),
																				new Normal('}',null,0,(char)VK.VK_0x7A,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x7A,null),
																										new Combination('}',null,0,(char)VK.VK_0x7A,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('B',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x7B,null),
																				new Normal('}',null,0,(char)VK.VK_0x7B,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x7B,null),
																										new Combination('}',null,0,(char)VK.VK_0x7B,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('C',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x7C,null),
																				new Normal('}',null,0,(char)VK.VK_0x7C,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x7C,null),
																										new Combination('}',null,0,(char)VK.VK_0x7C,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('D',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x7D,null),
																				new Normal('}',null,0,(char)VK.VK_0x7D,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x7D,null),
																										new Combination('}',null,0,(char)VK.VK_0x7D,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('E',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x7E,null),
																				new Normal('}',null,0,(char)VK.VK_0x7E,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x7E,null),
																										new Combination('}',null,0,(char)VK.VK_0x7E,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('F',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x7F,null),
																				new Normal('}',null,0,(char)VK.VK_0x7F,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x7F,null),
																										new Combination('}',null,0,(char)VK.VK_0x7F,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal('8',null,0,' ',new Base[]{
																			new Normal('0',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x80,null),
																				new Normal('}',null,0,(char)VK.VK_0x80,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x80,null),
																										new Combination('}',null,0,(char)VK.VK_0x80,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('1',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x81,null),
																				new Normal('}',null,0,(char)VK.VK_0x81,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x81,null),
																										new Combination('}',null,0,(char)VK.VK_0x81,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('2',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x82,null),
																				new Normal('}',null,0,(char)VK.VK_0x82,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x82,null),
																										new Combination('}',null,0,(char)VK.VK_0x82,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('3',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x83,null),
																				new Normal('}',null,0,(char)VK.VK_0x83,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x83,null),
																										new Combination('}',null,0,(char)VK.VK_0x83,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('4',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x84,null),
																				new Normal('}',null,0,(char)VK.VK_0x84,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x84,null),
																										new Combination('}',null,0,(char)VK.VK_0x84,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('5',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x85,null),
																				new Normal('}',null,0,(char)VK.VK_0x85,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x85,null),
																										new Combination('}',null,0,(char)VK.VK_0x85,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('6',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x86,null),
																				new Normal('}',null,0,(char)VK.VK_0x86,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x86,null),
																										new Combination('}',null,0,(char)VK.VK_0x86,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('7',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x87,null),
																				new Normal('}',null,0,(char)VK.VK_0x87,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x87,null),
																										new Combination('}',null,0,(char)VK.VK_0x87,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('8',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x88,null),
																				new Normal('}',null,0,(char)VK.VK_0x88,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x88,null),
																										new Combination('}',null,0,(char)VK.VK_0x88,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('9',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x89,null),
																				new Normal('}',null,0,(char)VK.VK_0x89,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x89,null),
																										new Combination('}',null,0,(char)VK.VK_0x89,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('A',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x8A,null),
																				new Normal('}',null,0,(char)VK.VK_0x8A,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x8A,null),
																										new Combination('}',null,0,(char)VK.VK_0x8A,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('B',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x8B,null),
																				new Normal('}',null,0,(char)VK.VK_0x8B,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x8B,null),
																										new Combination('}',null,0,(char)VK.VK_0x8B,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('C',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x8C,null),
																				new Normal('}',null,0,(char)VK.VK_0x8C,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x8C,null),
																										new Combination('}',null,0,(char)VK.VK_0x8C,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('D',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x8D,null),
																				new Normal('}',null,0,(char)VK.VK_0x8D,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x8D,null),
																										new Combination('}',null,0,(char)VK.VK_0x8D,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('E',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x8E,null),
																				new Normal('}',null,0,(char)VK.VK_0x8E,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x8E,null),
																										new Combination('}',null,0,(char)VK.VK_0x8E,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('F',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x8F,null),
																				new Normal('}',null,0,(char)VK.VK_0x8F,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x8F,null),
																										new Combination('}',null,0,(char)VK.VK_0x8F,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal('9',null,0,' ',new Base[]{
																			new Normal('0',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x90,null),
																				new Normal('}',null,0,(char)VK.VK_0x90,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x90,null),
																										new Combination('}',null,0,(char)VK.VK_0x90,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('1',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x91,null),
																				new Normal('}',null,0,(char)VK.VK_0x91,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x91,null),
																										new Combination('}',null,0,(char)VK.VK_0x91,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('2',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x92,null),
																				new Normal('}',null,0,(char)VK.VK_0x92,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x92,null),
																										new Combination('}',null,0,(char)VK.VK_0x92,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('3',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x93,null),
																				new Normal('}',null,0,(char)VK.VK_0x93,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x93,null),
																										new Combination('}',null,0,(char)VK.VK_0x93,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('4',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x94,null),
																				new Normal('}',null,0,(char)VK.VK_0x94,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x94,null),
																										new Combination('}',null,0,(char)VK.VK_0x94,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('5',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x95,null),
																				new Normal('}',null,0,(char)VK.VK_0x95,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x95,null),
																										new Combination('}',null,0,(char)VK.VK_0x95,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('6',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x96,null),
																				new Normal('}',null,0,(char)VK.VK_0x96,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x96,null),
																										new Combination('}',null,0,(char)VK.VK_0x96,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('7',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x97,null),
																				new Normal('}',null,0,(char)VK.VK_0x97,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x97,null),
																										new Combination('}',null,0,(char)VK.VK_0x97,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('8',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x98,null),
																				new Normal('}',null,0,(char)VK.VK_0x98,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x98,null),
																										new Combination('}',null,0,(char)VK.VK_0x98,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('9',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x99,null),
																				new Normal('}',null,0,(char)VK.VK_0x99,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x99,null),
																										new Combination('}',null,0,(char)VK.VK_0x99,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('A',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x9A,null),
																				new Normal('}',null,0,(char)VK.VK_0x9A,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x9A,null),
																										new Combination('}',null,0,(char)VK.VK_0x9A,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('B',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x9B,null),
																				new Normal('}',null,0,(char)VK.VK_0x9B,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x9B,null),
																										new Combination('}',null,0,(char)VK.VK_0x9B,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('C',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x9C,null),
																				new Normal('}',null,0,(char)VK.VK_0x9C,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x9C,null),
																										new Combination('}',null,0,(char)VK.VK_0x9C,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('D',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x9D,null),
																				new Normal('}',null,0,(char)VK.VK_0x9D,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x9D,null),
																										new Combination('}',null,0,(char)VK.VK_0x9D,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('E',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x9E,null),
																				new Normal('}',null,0,(char)VK.VK_0x9E,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x9E,null),
																										new Combination('}',null,0,(char)VK.VK_0x9E,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('F',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0x9F,null),
																				new Normal('}',null,0,(char)VK.VK_0x9F,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0x9F,null),
																										new Combination('}',null,0,(char)VK.VK_0x9F,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal('A',null,0,' ',new Base[]{
																			new Normal('0',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xA0,null),
																				new Normal('}',null,0,(char)VK.VK_0xA0,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xA0,null),
																										new Combination('}',null,0,(char)VK.VK_0xA0,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('1',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xA1,null),
																				new Normal('}',null,0,(char)VK.VK_0xA1,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xA1,null),
																										new Combination('}',null,0,(char)VK.VK_0xA1,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('2',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xA2,null),
																				new Normal('}',null,0,(char)VK.VK_0xA2,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xA2,null),
																										new Combination('}',null,0,(char)VK.VK_0xA2,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('3',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xA3,null),
																				new Normal('}',null,0,(char)VK.VK_0xA3,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xA3,null),
																										new Combination('}',null,0,(char)VK.VK_0xA3,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('4',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xA4,null),
																				new Normal('}',null,0,(char)VK.VK_0xA4,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xA4,null),
																										new Combination('}',null,0,(char)VK.VK_0xA4,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('5',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xA5,null),
																				new Normal('}',null,0,(char)VK.VK_0xA5,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xA5,null),
																										new Combination('}',null,0,(char)VK.VK_0xA5,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('6',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xA6,null),
																				new Normal('}',null,0,(char)VK.VK_0xA6,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xA6,null),
																										new Combination('}',null,0,(char)VK.VK_0xA6,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('7',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xA7,null),
																				new Normal('}',null,0,(char)VK.VK_0xA7,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xA7,null),
																										new Combination('}',null,0,(char)VK.VK_0xA7,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('8',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xA8,null),
																				new Normal('}',null,0,(char)VK.VK_0xA8,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xA8,null),
																										new Combination('}',null,0,(char)VK.VK_0xA8,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('9',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xA9,null),
																				new Normal('}',null,0,(char)VK.VK_0xA9,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xA9,null),
																										new Combination('}',null,0,(char)VK.VK_0xA9,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('A',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xAA,null),
																				new Normal('}',null,0,(char)VK.VK_0xAA,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xAA,null),
																										new Combination('}',null,0,(char)VK.VK_0xAA,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('B',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xAB,null),
																				new Normal('}',null,0,(char)VK.VK_0xAB,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xAB,null),
																										new Combination('}',null,0,(char)VK.VK_0xAB,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('C',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xAC,null),
																				new Normal('}',null,0,(char)VK.VK_0xAC,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xAC,null),
																										new Combination('}',null,0,(char)VK.VK_0xAC,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('D',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xAD,null),
																				new Normal('}',null,0,(char)VK.VK_0xAD,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xAD,null),
																										new Combination('}',null,0,(char)VK.VK_0xAD,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('E',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xAE,null),
																				new Normal('}',null,0,(char)VK.VK_0xAE,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xAE,null),
																										new Combination('}',null,0,(char)VK.VK_0xAE,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('F',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xAF,null),
																				new Normal('}',null,0,(char)VK.VK_0xAF,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xAF,null),
																										new Combination('}',null,0,(char)VK.VK_0xAF,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal('B',null,0,' ',new Base[]{
																			new Normal('0',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xB0,null),
																				new Normal('}',null,0,(char)VK.VK_0xB0,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xB0,null),
																										new Combination('}',null,0,(char)VK.VK_0xB0,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('1',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xB1,null),
																				new Normal('}',null,0,(char)VK.VK_0xB1,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xB1,null),
																										new Combination('}',null,0,(char)VK.VK_0xB1,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('2',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xB2,null),
																				new Normal('}',null,0,(char)VK.VK_0xB2,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xB2,null),
																										new Combination('}',null,0,(char)VK.VK_0xB2,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('3',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xB3,null),
																				new Normal('}',null,0,(char)VK.VK_0xB3,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xB3,null),
																										new Combination('}',null,0,(char)VK.VK_0xB3,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('4',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xB4,null),
																				new Normal('}',null,0,(char)VK.VK_0xB4,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xB4,null),
																										new Combination('}',null,0,(char)VK.VK_0xB4,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('5',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xB5,null),
																				new Normal('}',null,0,(char)VK.VK_0xB5,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xB5,null),
																										new Combination('}',null,0,(char)VK.VK_0xB5,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('6',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xB6,null),
																				new Normal('}',null,0,(char)VK.VK_0xB6,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xB6,null),
																										new Combination('}',null,0,(char)VK.VK_0xB6,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('7',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xB7,null),
																				new Normal('}',null,0,(char)VK.VK_0xB7,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xB7,null),
																										new Combination('}',null,0,(char)VK.VK_0xB7,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('8',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xB8,null),
																				new Normal('}',null,0,(char)VK.VK_0xB8,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xB8,null),
																										new Combination('}',null,0,(char)VK.VK_0xB8,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('9',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xB9,null),
																				new Normal('}',null,0,(char)VK.VK_0xB9,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xB9,null),
																										new Combination('}',null,0,(char)VK.VK_0xB9,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('A',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xBA,null),
																				new Normal('}',null,0,(char)VK.VK_0xBA,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xBA,null),
																										new Combination('}',null,0,(char)VK.VK_0xBA,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('B',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xBB,null),
																				new Normal('}',null,0,(char)VK.VK_0xBB,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xBB,null),
																										new Combination('}',null,0,(char)VK.VK_0xBB,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('C',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xBC,null),
																				new Normal('}',null,0,(char)VK.VK_0xBC,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xBC,null),
																										new Combination('}',null,0,(char)VK.VK_0xBC,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('D',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xBD,null),
																				new Normal('}',null,0,(char)VK.VK_0xBD,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xBD,null),
																										new Combination('}',null,0,(char)VK.VK_0xBD,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('E',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xBE,null),
																				new Normal('}',null,0,(char)VK.VK_0xBE,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xBE,null),
																										new Combination('}',null,0,(char)VK.VK_0xBE,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('F',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xBF,null),
																				new Normal('}',null,0,(char)VK.VK_0xBF,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xBF,null),
																										new Combination('}',null,0,(char)VK.VK_0xBF,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal('C',null,0,' ',new Base[]{
																			new Normal('0',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xC0,null),
																				new Normal('}',null,0,(char)VK.VK_0xC0,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xC0,null),
																										new Combination('}',null,0,(char)VK.VK_0xC0,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('1',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xC1,null),
																				new Normal('}',null,0,(char)VK.VK_0xC1,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xC1,null),
																										new Combination('}',null,0,(char)VK.VK_0xC1,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('2',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xC2,null),
																				new Normal('}',null,0,(char)VK.VK_0xC2,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xC2,null),
																										new Combination('}',null,0,(char)VK.VK_0xC2,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('3',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xC3,null),
																				new Normal('}',null,0,(char)VK.VK_0xC3,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xC3,null),
																										new Combination('}',null,0,(char)VK.VK_0xC3,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('4',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xC4,null),
																				new Normal('}',null,0,(char)VK.VK_0xC4,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xC4,null),
																										new Combination('}',null,0,(char)VK.VK_0xC4,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('5',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xC5,null),
																				new Normal('}',null,0,(char)VK.VK_0xC5,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xC5,null),
																										new Combination('}',null,0,(char)VK.VK_0xC5,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('6',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xC6,null),
																				new Normal('}',null,0,(char)VK.VK_0xC6,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xC6,null),
																										new Combination('}',null,0,(char)VK.VK_0xC6,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('7',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xC7,null),
																				new Normal('}',null,0,(char)VK.VK_0xC7,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xC7,null),
																										new Combination('}',null,0,(char)VK.VK_0xC7,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('8',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xC8,null),
																				new Normal('}',null,0,(char)VK.VK_0xC8,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xC8,null),
																										new Combination('}',null,0,(char)VK.VK_0xC8,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('9',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xC9,null),
																				new Normal('}',null,0,(char)VK.VK_0xC9,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xC9,null),
																										new Combination('}',null,0,(char)VK.VK_0xC9,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('A',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xCA,null),
																				new Normal('}',null,0,(char)VK.VK_0xCA,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xCA,null),
																										new Combination('}',null,0,(char)VK.VK_0xCA,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('B',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xCB,null),
																				new Normal('}',null,0,(char)VK.VK_0xCB,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xCB,null),
																										new Combination('}',null,0,(char)VK.VK_0xCB,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('C',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xCC,null),
																				new Normal('}',null,0,(char)VK.VK_0xCC,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xCC,null),
																										new Combination('}',null,0,(char)VK.VK_0xCC,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('D',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xCD,null),
																				new Normal('}',null,0,(char)VK.VK_0xCD,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xCD,null),
																										new Combination('}',null,0,(char)VK.VK_0xCD,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('E',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xCE,null),
																				new Normal('}',null,0,(char)VK.VK_0xCE,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xCE,null),
																										new Combination('}',null,0,(char)VK.VK_0xCE,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('F',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xCF,null),
																				new Normal('}',null,0,(char)VK.VK_0xCF,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xCF,null),
																										new Combination('}',null,0,(char)VK.VK_0xCF,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal('D',null,0,' ',new Base[]{
																			new Normal('0',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xD0,null),
																				new Normal('}',null,0,(char)VK.VK_0xD0,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xD0,null),
																										new Combination('}',null,0,(char)VK.VK_0xD0,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('1',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xD1,null),
																				new Normal('}',null,0,(char)VK.VK_0xD1,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xD1,null),
																										new Combination('}',null,0,(char)VK.VK_0xD1,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('2',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xD2,null),
																				new Normal('}',null,0,(char)VK.VK_0xD2,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xD2,null),
																										new Combination('}',null,0,(char)VK.VK_0xD2,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('3',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xD3,null),
																				new Normal('}',null,0,(char)VK.VK_0xD3,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xD3,null),
																										new Combination('}',null,0,(char)VK.VK_0xD3,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('4',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xD4,null),
																				new Normal('}',null,0,(char)VK.VK_0xD4,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xD4,null),
																										new Combination('}',null,0,(char)VK.VK_0xD4,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('5',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xD5,null),
																				new Normal('}',null,0,(char)VK.VK_0xD5,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xD5,null),
																										new Combination('}',null,0,(char)VK.VK_0xD5,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('6',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xD6,null),
																				new Normal('}',null,0,(char)VK.VK_0xD6,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xD6,null),
																										new Combination('}',null,0,(char)VK.VK_0xD6,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('7',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xD7,null),
																				new Normal('}',null,0,(char)VK.VK_0xD7,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xD7,null),
																										new Combination('}',null,0,(char)VK.VK_0xD7,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('8',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xD8,null),
																				new Normal('}',null,0,(char)VK.VK_0xD8,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xD8,null),
																										new Combination('}',null,0,(char)VK.VK_0xD8,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('9',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xD9,null),
																				new Normal('}',null,0,(char)VK.VK_0xD9,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xD9,null),
																										new Combination('}',null,0,(char)VK.VK_0xD9,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('A',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xDA,null),
																				new Normal('}',null,0,(char)VK.VK_0xDA,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xDA,null),
																										new Combination('}',null,0,(char)VK.VK_0xDA,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('B',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xDB,null),
																				new Normal('}',null,0,(char)VK.VK_0xDB,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xDB,null),
																										new Combination('}',null,0,(char)VK.VK_0xDB,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('C',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xDC,null),
																				new Normal('}',null,0,(char)VK.VK_0xDC,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xDC,null),
																										new Combination('}',null,0,(char)VK.VK_0xDC,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('D',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xDD,null),
																				new Normal('}',null,0,(char)VK.VK_0xDD,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xDD,null),
																										new Combination('}',null,0,(char)VK.VK_0xDD,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('E',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xDE,null),
																				new Normal('}',null,0,(char)VK.VK_0xDE,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xDE,null),
																										new Combination('}',null,0,(char)VK.VK_0xDE,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('F',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xDF,null),
																				new Normal('}',null,0,(char)VK.VK_0xDF,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xDF,null),
																										new Combination('}',null,0,(char)VK.VK_0xDF,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal('E',null,0,' ',new Base[]{
																			new Normal('0',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xE0,null),
																				new Normal('}',null,0,(char)VK.VK_0xE0,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xE0,null),
																										new Combination('}',null,0,(char)VK.VK_0xE0,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('1',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xE1,null),
																				new Normal('}',null,0,(char)VK.VK_0xE1,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xE1,null),
																										new Combination('}',null,0,(char)VK.VK_0xE1,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('2',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xE2,null),
																				new Normal('}',null,0,(char)VK.VK_0xE2,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xE2,null),
																										new Combination('}',null,0,(char)VK.VK_0xE2,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('3',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xE3,null),
																				new Normal('}',null,0,(char)VK.VK_0xE3,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xE3,null),
																										new Combination('}',null,0,(char)VK.VK_0xE3,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('4',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xE4,null),
																				new Normal('}',null,0,(char)VK.VK_0xE4,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xE4,null),
																										new Combination('}',null,0,(char)VK.VK_0xE4,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('5',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xE5,null),
																				new Normal('}',null,0,(char)VK.VK_0xE5,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xE5,null),
																										new Combination('}',null,0,(char)VK.VK_0xE5,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('6',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xE6,null),
																				new Normal('}',null,0,(char)VK.VK_0xE6,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xE6,null),
																										new Combination('}',null,0,(char)VK.VK_0xE6,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('7',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xE7,null),
																				new Normal('}',null,0,(char)VK.VK_0xE7,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xE7,null),
																										new Combination('}',null,0,(char)VK.VK_0xE7,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('8',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xE8,null),
																				new Normal('}',null,0,(char)VK.VK_0xE8,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xE8,null),
																										new Combination('}',null,0,(char)VK.VK_0xE8,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('9',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xE9,null),
																				new Normal('}',null,0,(char)VK.VK_0xE9,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xE9,null),
																										new Combination('}',null,0,(char)VK.VK_0xE9,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('A',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xEA,null),
																				new Normal('}',null,0,(char)VK.VK_0xEA,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xEA,null),
																										new Combination('}',null,0,(char)VK.VK_0xEA,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('B',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xEB,null),
																				new Normal('}',null,0,(char)VK.VK_0xEB,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xEB,null),
																										new Combination('}',null,0,(char)VK.VK_0xEB,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('C',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xEC,null),
																				new Normal('}',null,0,(char)VK.VK_0xEC,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xEC,null),
																										new Combination('}',null,0,(char)VK.VK_0xEC,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('D',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xED,null),
																				new Normal('}',null,0,(char)VK.VK_0xED,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xED,null),
																										new Combination('}',null,0,(char)VK.VK_0xED,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('E',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xEE,null),
																				new Normal('}',null,0,(char)VK.VK_0xEE,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xEE,null),
																										new Combination('}',null,0,(char)VK.VK_0xEE,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('F',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xEF,null),
																				new Normal('}',null,0,(char)VK.VK_0xEF,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xEF,null),
																										new Combination('}',null,0,(char)VK.VK_0xEF,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal('F',null,0,' ',new Base[]{
																			new Normal('0',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xF0,null),
																				new Normal('}',null,0,(char)VK.VK_0xF0,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xF0,null),
																										new Combination('}',null,0,(char)VK.VK_0xF0,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('1',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xF1,null),
																				new Normal('}',null,0,(char)VK.VK_0xF1,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xF1,null),
																										new Combination('}',null,0,(char)VK.VK_0xF1,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('2',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xF2,null),
																				new Normal('}',null,0,(char)VK.VK_0xF2,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xF2,null),
																										new Combination('}',null,0,(char)VK.VK_0xF2,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('3',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xF3,null),
																				new Normal('}',null,0,(char)VK.VK_0xF3,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xF3,null),
																										new Combination('}',null,0,(char)VK.VK_0xF3,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('4',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xF4,null),
																				new Normal('}',null,0,(char)VK.VK_0xF4,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xF4,null),
																										new Combination('}',null,0,(char)VK.VK_0xF4,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('5',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xF5,null),
																				new Normal('}',null,0,(char)VK.VK_0xF5,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xF5,null),
																										new Combination('}',null,0,(char)VK.VK_0xF5,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('6',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xF6,null),
																				new Normal('}',null,0,(char)VK.VK_0xF6,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xF6,null),
																										new Combination('}',null,0,(char)VK.VK_0xF6,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('7',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xF7,null),
																				new Normal('}',null,0,(char)VK.VK_0xF7,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xF7,null),
																										new Combination('}',null,0,(char)VK.VK_0xF7,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('8',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xF8,null),
																				new Normal('}',null,0,(char)VK.VK_0xF8,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xF8,null),
																										new Combination('}',null,0,(char)VK.VK_0xF8,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('9',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xF9,null),
																				new Normal('}',null,0,(char)VK.VK_0xF9,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xF9,null),
																										new Combination('}',null,0,(char)VK.VK_0xF9,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('A',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xFA,null),
																				new Normal('}',null,0,(char)VK.VK_0xFA,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xFA,null),
																										new Combination('}',null,0,(char)VK.VK_0xFA,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('B',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xFB,null),
																				new Normal('}',null,0,(char)VK.VK_0xFB,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xFB,null),
																										new Combination('}',null,0,(char)VK.VK_0xFB,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('C',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xFC,null),
																				new Normal('}',null,0,(char)VK.VK_0xFC,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xFC,null),
																										new Combination('}',null,0,(char)VK.VK_0xFC,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('D',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xFD,null),
																				new Normal('}',null,0,(char)VK.VK_0xFD,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xFD,null),
																										new Combination('}',null,0,(char)VK.VK_0xFD,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('E',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xFE,null),
																				new Normal('}',null,0,(char)VK.VK_0xFE,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xFE,null),
																										new Combination('}',null,0,(char)VK.VK_0xFE,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('F',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_0xFF,null),
																				new Normal('}',null,0,(char)VK.VK_0xFF,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_0xFF,null),
																										new Combination('}',null,0,(char)VK.VK_0xFF,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal(null,ParseException,0,' ',null)
																}),
																new Normal('1',null,0,' ',new Base[]{
																	new NormalLoop(' ',null,0,(char)VK.VK_1,null),
																	new Normal('}',null,0,(char)VK.VK_1,null),
																	new Normal('.',null,0,' ',new Base[]{
																		new Normal('C',null,0,' ',new Base[]{
																			new Normal('O',null,0,' ',new Base[]{
																				new Normal('M',null,0,' ',new Base[]{
																					new Normal('B',null,0,' ',new Base[]{
																						new Normal('I',null,0,' ',new Base[]{
																							new CombinationLoop(' ',null,0,(char)VK.VK_1,null),
																							new Combination('}',null,0,(char)VK.VK_1,null),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal(null,ParseException,0,' ',null)
																}),
																new Normal('2',null,0,' ',new Base[]{
																	new NormalLoop(' ',null,0,(char)VK.VK_2,null),
																	new Normal('}',null,0,(char)VK.VK_2,null),
																	new Normal('.',null,0,' ',new Base[]{
																		new Normal('C',null,0,' ',new Base[]{
																			new Normal('O',null,0,' ',new Base[]{
																				new Normal('M',null,0,' ',new Base[]{
																					new Normal('B',null,0,' ',new Base[]{
																						new Normal('I',null,0,' ',new Base[]{
																							new CombinationLoop(' ',null,0,(char)VK.VK_2,null),
																							new Combination('}',null,0,(char)VK.VK_2,null),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal(null,ParseException,0,' ',null)
																}),
																new Normal('3',null,0,' ',new Base[]{
																	new NormalLoop(' ',null,0,(char)VK.VK_3,null),
																	new Normal('}',null,0,(char)VK.VK_3,null),
																	new Normal('.',null,0,' ',new Base[]{
																		new Normal('C',null,0,' ',new Base[]{
																			new Normal('O',null,0,' ',new Base[]{
																				new Normal('M',null,0,' ',new Base[]{
																					new Normal('B',null,0,' ',new Base[]{
																						new Normal('I',null,0,' ',new Base[]{
																							new CombinationLoop(' ',null,0,(char)VK.VK_3,null),
																							new Combination('}',null,0,(char)VK.VK_3,null),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal(null,ParseException,0,' ',null)
																}),
																new Normal('4',null,0,' ',new Base[]{
																	new NormalLoop(' ',null,0,(char)VK.VK_4,null),
																	new Normal('}',null,0,(char)VK.VK_4,null),
																	new Normal('.',null,0,' ',new Base[]{
																		new Normal('C',null,0,' ',new Base[]{
																			new Normal('O',null,0,' ',new Base[]{
																				new Normal('M',null,0,' ',new Base[]{
																					new Normal('B',null,0,' ',new Base[]{
																						new Normal('I',null,0,' ',new Base[]{
																							new CombinationLoop(' ',null,0,(char)VK.VK_4,null),
																							new Combination('}',null,0,(char)VK.VK_4,null),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal(null,ParseException,0,' ',null)
																}),
																new Normal('5',null,0,' ',new Base[]{
																	new NormalLoop(' ',null,0,(char)VK.VK_5,null),
																	new Normal('}',null,0,(char)VK.VK_5,null),
																	new Normal('.',null,0,' ',new Base[]{
																		new Normal('C',null,0,' ',new Base[]{
																			new Normal('O',null,0,' ',new Base[]{
																				new Normal('M',null,0,' ',new Base[]{
																					new Normal('B',null,0,' ',new Base[]{
																						new Normal('I',null,0,' ',new Base[]{
																							new CombinationLoop(' ',null,0,(char)VK.VK_5,null),
																							new Combination('}',null,0,(char)VK.VK_5,null),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal(null,ParseException,0,' ',null)
																}),
																new Normal('6',null,0,' ',new Base[]{
																	new NormalLoop(' ',null,0,(char)VK.VK_6,null),
																	new Normal('}',null,0,(char)VK.VK_6,null),
																	new Normal('.',null,0,' ',new Base[]{
																		new Normal('C',null,0,' ',new Base[]{
																			new Normal('O',null,0,' ',new Base[]{
																				new Normal('M',null,0,' ',new Base[]{
																					new Normal('B',null,0,' ',new Base[]{
																						new Normal('I',null,0,' ',new Base[]{
																							new CombinationLoop(' ',null,0,(char)VK.VK_6,null),
																							new Combination('}',null,0,(char)VK.VK_6,null),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal(null,ParseException,0,' ',null)
																}),
																new Normal('7',null,0,' ',new Base[]{
																	new NormalLoop(' ',null,0,(char)VK.VK_7,null),
																	new Normal('}',null,0,(char)VK.VK_7,null),
																	new Normal('.',null,0,' ',new Base[]{
																		new Normal('C',null,0,' ',new Base[]{
																			new Normal('O',null,0,' ',new Base[]{
																				new Normal('M',null,0,' ',new Base[]{
																					new Normal('B',null,0,' ',new Base[]{
																						new Normal('I',null,0,' ',new Base[]{
																							new CombinationLoop(' ',null,0,(char)VK.VK_7,null),
																							new Combination('}',null,0,(char)VK.VK_7,null),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal(null,ParseException,0,' ',null)
																}),
																new Normal('8',null,0,' ',new Base[]{
																	new NormalLoop(' ',null,0,(char)VK.VK_8,null),
																	new Normal('}',null,0,(char)VK.VK_8,null),
																	new Normal('.',null,0,' ',new Base[]{
																		new Normal('C',null,0,' ',new Base[]{
																			new Normal('O',null,0,' ',new Base[]{
																				new Normal('M',null,0,' ',new Base[]{
																					new Normal('B',null,0,' ',new Base[]{
																						new Normal('I',null,0,' ',new Base[]{
																							new CombinationLoop(' ',null,0,(char)VK.VK_8,null),
																							new Combination('}',null,0,(char)VK.VK_8,null),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal(null,ParseException,0,' ',null)
																}),
																new Normal('9',null,0,' ',new Base[]{
																	new NormalLoop(' ',null,0,(char)VK.VK_9,null),
																	new Normal('}',null,0,(char)VK.VK_9,null),
																	new Normal('.',null,0,' ',new Base[]{
																		new Normal('C',null,0,' ',new Base[]{
																			new Normal('O',null,0,' ',new Base[]{
																				new Normal('M',null,0,' ',new Base[]{
																					new Normal('B',null,0,' ',new Base[]{
																						new Normal('I',null,0,' ',new Base[]{
																							new CombinationLoop(' ',null,0,(char)VK.VK_9,null),
																							new Combination('}',null,0,(char)VK.VK_9,null),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal(null,ParseException,0,' ',null)
																}),
																new Normal('A',null,0,' ',new Base[]{
																	new NormalLoop(' ',null,0,(char)VK.VK_A,null),
																	new Normal('}',null,0,(char)VK.VK_A,null),
																	new Normal('.',null,0,' ',new Base[]{
																		new Normal('C',null,0,' ',new Base[]{
																			new Normal('O',null,0,' ',new Base[]{
																				new Normal('M',null,0,' ',new Base[]{
																					new Normal('B',null,0,' ',new Base[]{
																						new Normal('I',null,0,' ',new Base[]{
																							new CombinationLoop(' ',null,0,(char)VK.VK_A,null),
																							new Combination('}',null,0,(char)VK.VK_A,null),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal('C',null,0,' ',new Base[]{
																		new Normal('C',null,0,' ',new Base[]{
																			new Normal('E',null,0,' ',new Base[]{
																				new Normal('P',null,0,' ',new Base[]{
																					new Normal('T',null,0,' ',new Base[]{
																						new NormalLoop(' ',null,0,(char)VK.VK_ACCEPT,null),
																						new Normal('}',null,0,(char)VK.VK_ACCEPT,null),
																						new Normal('.',null,0,' ',new Base[]{
																							new Normal('C',null,0,' ',new Base[]{
																								new Normal('O',null,0,' ',new Base[]{
																									new Normal('M',null,0,' ',new Base[]{
																										new Normal('B',null,0,' ',new Base[]{
																											new Normal('I',null,0,' ',new Base[]{
																												new CombinationLoop(' ',null,0,(char)VK.VK_ACCEPT,null),
																												new Combination('}',null,0,(char)VK.VK_ACCEPT,null),
																												new Normal(null,ParseException,0,' ',null)
																											}),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal('D',null,0,' ',new Base[]{
																		new Normal('D',null,0,' ',new Base[]{
																			new NormalLoop(' ',null,0,(char)VK.VK_ADD,null),
																			new Normal('}',null,0,(char)VK.VK_ADD,null),
																			new Normal('.',null,0,' ',new Base[]{
																				new Normal('C',null,0,' ',new Base[]{
																					new Normal('O',null,0,' ',new Base[]{
																						new Normal('M',null,0,' ',new Base[]{
																							new Normal('B',null,0,' ',new Base[]{
																								new Normal('I',null,0,' ',new Base[]{
																									new CombinationLoop(' ',null,0,(char)VK.VK_ADD,null),
																									new Combination('}',null,0,(char)VK.VK_ADD,null),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal('P',null,0,' ',new Base[]{
																		new Normal('P',null,0,' ',new Base[]{
																			new Normal('S',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_APPS,null),
																				new Normal('}',null,0,(char)VK.VK_APPS,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_APPS,null),
																										new Combination('}',null,0,(char)VK.VK_APPS,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal('T',null,0,' ',new Base[]{
																		new Normal('T',null,0,' ',new Base[]{
																			new Normal('N',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_ATTN,null),
																				new Normal('}',null,0,(char)VK.VK_ATTN,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_ATTN,null),
																										new Combination('}',null,0,(char)VK.VK_ATTN,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal(null,ParseException,0,' ',null)
																}),
																new Normal('B',null,0,' ',new Base[]{
																	new NormalLoop(' ',null,0,(char)VK.VK_B,null),
																	new Normal('}',null,0,(char)VK.VK_B,null),
																	new Normal('.',null,0,' ',new Base[]{
																		new Normal('C',null,0,' ',new Base[]{
																			new Normal('O',null,0,' ',new Base[]{
																				new Normal('M',null,0,' ',new Base[]{
																					new Normal('B',null,0,' ',new Base[]{
																						new Normal('I',null,0,' ',new Base[]{
																							new CombinationLoop(' ',null,0,(char)VK.VK_B,null),
																							new Combination('}',null,0,(char)VK.VK_B,null),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal('A',null,0,' ',new Base[]{
																		new Normal('C',null,0,' ',new Base[]{
																			new Normal('K',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_BACK,null),
																				new Normal('}',null,0,(char)VK.VK_BACK,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_BACK,null),
																										new Combination('}',null,0,(char)VK.VK_BACK,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal('R',null,0,' ',new Base[]{
																		new Normal('O',null,0,' ',new Base[]{
																			new Normal('W',null,0,' ',new Base[]{
																				new Normal('S',null,0,' ',new Base[]{
																					new Normal('E',null,0,' ',new Base[]{
																						new Normal('R',null,0,' ',new Base[]{
																							new Normal('_',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('A',null,0,' ',new Base[]{
																										new Normal('C',null,0,' ',new Base[]{
																											new Normal('K',null,0,' ',new Base[]{
																												new NormalLoop(' ',null,0,(char)VK.VK_BROWSER_BACK,null),
																												new Normal('}',null,0,(char)VK.VK_BROWSER_BACK,null),
																												new Normal('.',null,0,' ',new Base[]{
																													new Normal('C',null,0,' ',new Base[]{
																														new Normal('O',null,0,' ',new Base[]{
																															new Normal('M',null,0,' ',new Base[]{
																																new Normal('B',null,0,' ',new Base[]{
																																	new Normal('I',null,0,' ',new Base[]{
																																		new CombinationLoop(' ',null,0,(char)VK.VK_BROWSER_BACK,null),
																																		new Combination('}',null,0,(char)VK.VK_BROWSER_BACK,null),
																																		new Normal(null,ParseException,0,' ',null)
																																	}),
																																	new Normal(null,ParseException,0,' ',null)
																																}),
																																new Normal(null,ParseException,0,' ',null)
																															}),
																															new Normal(null,ParseException,0,' ',null)
																														}),
																														new Normal(null,ParseException,0,' ',null)
																													}),
																													new Normal(null,ParseException,0,' ',null)
																												}),
																												new Normal(null,ParseException,0,' ',null)
																											}),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal('F',null,0,' ',new Base[]{
																									new Normal('A',null,0,' ',new Base[]{
																										new Normal('V',null,0,' ',new Base[]{
																											new Normal('O',null,0,' ',new Base[]{
																												new Normal('R',null,0,' ',new Base[]{
																													new Normal('I',null,0,' ',new Base[]{
																														new Normal('T',null,0,' ',new Base[]{
																															new Normal('E',null,0,' ',new Base[]{
																																new Normal('S',null,0,' ',new Base[]{
																																	new NormalLoop(' ',null,0,(char)VK.VK_BROWSER_FAVORITES,null),
																																	new Normal('}',null,0,(char)VK.VK_BROWSER_FAVORITES,null),
																																	new Normal('.',null,0,' ',new Base[]{
																																		new Normal('C',null,0,' ',new Base[]{
																																			new Normal('O',null,0,' ',new Base[]{
																																				new Normal('M',null,0,' ',new Base[]{
																																					new Normal('B',null,0,' ',new Base[]{
																																						new Normal('I',null,0,' ',new Base[]{
																																							new CombinationLoop(' ',null,0,(char)VK.VK_BROWSER_FAVORITES,null),
																																							new Combination('}',null,0,(char)VK.VK_BROWSER_FAVORITES,null),
																																							new Normal(null,ParseException,0,' ',null)
																																						}),
																																						new Normal(null,ParseException,0,' ',null)
																																					}),
																																					new Normal(null,ParseException,0,' ',null)
																																				}),
																																				new Normal(null,ParseException,0,' ',null)
																																			}),
																																			new Normal(null,ParseException,0,' ',null)
																																		}),
																																		new Normal(null,ParseException,0,' ',null)
																																	}),
																																	new Normal(null,ParseException,0,' ',null)
																																}),
																																new Normal(null,ParseException,0,' ',null)
																															}),
																															new Normal(null,ParseException,0,' ',null)
																														}),
																														new Normal(null,ParseException,0,' ',null)
																													}),
																													new Normal(null,ParseException,0,' ',null)
																												}),
																												new Normal(null,ParseException,0,' ',null)
																											}),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal('O',null,0,' ',new Base[]{
																										new Normal('R',null,0,' ',new Base[]{
																											new Normal('W',null,0,' ',new Base[]{
																												new Normal('A',null,0,' ',new Base[]{
																													new Normal('R',null,0,' ',new Base[]{
																														new Normal('D',null,0,' ',new Base[]{
																															new NormalLoop(' ',null,0,(char)VK.VK_BROWSER_FORWARD,null),
																															new Normal('}',null,0,(char)VK.VK_BROWSER_FORWARD,null),
																															new Normal('.',null,0,' ',new Base[]{
																																new Normal('C',null,0,' ',new Base[]{
																																	new Normal('O',null,0,' ',new Base[]{
																																		new Normal('M',null,0,' ',new Base[]{
																																			new Normal('B',null,0,' ',new Base[]{
																																				new Normal('I',null,0,' ',new Base[]{
																																					new CombinationLoop(' ',null,0,(char)VK.VK_BROWSER_FORWARD,null),
																																					new Combination('}',null,0,(char)VK.VK_BROWSER_FORWARD,null),
																																					new Normal(null,ParseException,0,' ',null)
																																				}),
																																				new Normal(null,ParseException,0,' ',null)
																																			}),
																																			new Normal(null,ParseException,0,' ',null)
																																		}),
																																		new Normal(null,ParseException,0,' ',null)
																																	}),
																																	new Normal(null,ParseException,0,' ',null)
																																}),
																																new Normal(null,ParseException,0,' ',null)
																															}),
																															new Normal(null,ParseException,0,' ',null)
																														}),
																														new Normal(null,ParseException,0,' ',null)
																													}),
																													new Normal(null,ParseException,0,' ',null)
																												}),
																												new Normal(null,ParseException,0,' ',null)
																											}),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal('H',null,0,' ',new Base[]{
																									new Normal('O',null,0,' ',new Base[]{
																										new Normal('M',null,0,' ',new Base[]{
																											new Normal('E',null,0,' ',new Base[]{
																												new NormalLoop(' ',null,0,(char)VK.VK_BROWSER_HOME,null),
																												new Normal('}',null,0,(char)VK.VK_BROWSER_HOME,null),
																												new Normal('.',null,0,' ',new Base[]{
																													new Normal('C',null,0,' ',new Base[]{
																														new Normal('O',null,0,' ',new Base[]{
																															new Normal('M',null,0,' ',new Base[]{
																																new Normal('B',null,0,' ',new Base[]{
																																	new Normal('I',null,0,' ',new Base[]{
																																		new CombinationLoop(' ',null,0,(char)VK.VK_BROWSER_HOME,null),
																																		new Combination('}',null,0,(char)VK.VK_BROWSER_HOME,null),
																																		new Normal(null,ParseException,0,' ',null)
																																	}),
																																	new Normal(null,ParseException,0,' ',null)
																																}),
																																new Normal(null,ParseException,0,' ',null)
																															}),
																															new Normal(null,ParseException,0,' ',null)
																														}),
																														new Normal(null,ParseException,0,' ',null)
																													}),
																													new Normal(null,ParseException,0,' ',null)
																												}),
																												new Normal(null,ParseException,0,' ',null)
																											}),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal('R',null,0,' ',new Base[]{
																									new Normal('E',null,0,' ',new Base[]{
																										new Normal('F',null,0,' ',new Base[]{
																											new Normal('R',null,0,' ',new Base[]{
																												new Normal('E',null,0,' ',new Base[]{
																													new Normal('S',null,0,' ',new Base[]{
																														new Normal('H',null,0,' ',new Base[]{
																															new NormalLoop(' ',null,0,(char)VK.VK_BROWSER_REFRESH,null),
																															new Normal('}',null,0,(char)VK.VK_BROWSER_REFRESH,null),
																															new Normal('.',null,0,' ',new Base[]{
																																new Normal('C',null,0,' ',new Base[]{
																																	new Normal('O',null,0,' ',new Base[]{
																																		new Normal('M',null,0,' ',new Base[]{
																																			new Normal('B',null,0,' ',new Base[]{
																																				new Normal('I',null,0,' ',new Base[]{
																																					new CombinationLoop(' ',null,0,(char)VK.VK_BROWSER_REFRESH,null),
																																					new Combination('}',null,0,(char)VK.VK_BROWSER_REFRESH,null),
																																					new Normal(null,ParseException,0,' ',null)
																																				}),
																																				new Normal(null,ParseException,0,' ',null)
																																			}),
																																			new Normal(null,ParseException,0,' ',null)
																																		}),
																																		new Normal(null,ParseException,0,' ',null)
																																	}),
																																	new Normal(null,ParseException,0,' ',null)
																																}),
																																new Normal(null,ParseException,0,' ',null)
																															}),
																															new Normal(null,ParseException,0,' ',null)
																														}),
																														new Normal(null,ParseException,0,' ',null)
																													}),
																													new Normal(null,ParseException,0,' ',null)
																												}),
																												new Normal(null,ParseException,0,' ',null)
																											}),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal('S',null,0,' ',new Base[]{
																									new Normal('E',null,0,' ',new Base[]{
																										new Normal('A',null,0,' ',new Base[]{
																											new Normal('R',null,0,' ',new Base[]{
																												new Normal('C',null,0,' ',new Base[]{
																													new Normal('H',null,0,' ',new Base[]{
																														new NormalLoop(' ',null,0,(char)VK.VK_BROWSER_SEARCH,null),
																														new Normal('}',null,0,(char)VK.VK_BROWSER_SEARCH,null),
																														new Normal('.',null,0,' ',new Base[]{
																															new Normal('C',null,0,' ',new Base[]{
																																new Normal('O',null,0,' ',new Base[]{
																																	new Normal('M',null,0,' ',new Base[]{
																																		new Normal('B',null,0,' ',new Base[]{
																																			new Normal('I',null,0,' ',new Base[]{
																																				new CombinationLoop(' ',null,0,(char)VK.VK_BROWSER_SEARCH,null),
																																				new Combination('}',null,0,(char)VK.VK_BROWSER_SEARCH,null),
																																				new Normal(null,ParseException,0,' ',null)
																																			}),
																																			new Normal(null,ParseException,0,' ',null)
																																		}),
																																		new Normal(null,ParseException,0,' ',null)
																																	}),
																																	new Normal(null,ParseException,0,' ',null)
																																}),
																																new Normal(null,ParseException,0,' ',null)
																															}),
																															new Normal(null,ParseException,0,' ',null)
																														}),
																														new Normal(null,ParseException,0,' ',null)
																													}),
																													new Normal(null,ParseException,0,' ',null)
																												}),
																												new Normal(null,ParseException,0,' ',null)
																											}),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal('T',null,0,' ',new Base[]{
																										new Normal('O',null,0,' ',new Base[]{
																											new Normal('P',null,0,' ',new Base[]{
																												new NormalLoop(' ',null,0,(char)VK.VK_BROWSER_STOP,null),
																												new Normal('}',null,0,(char)VK.VK_BROWSER_STOP,null),
																												new Normal('.',null,0,' ',new Base[]{
																													new Normal('C',null,0,' ',new Base[]{
																														new Normal('O',null,0,' ',new Base[]{
																															new Normal('M',null,0,' ',new Base[]{
																																new Normal('B',null,0,' ',new Base[]{
																																	new Normal('I',null,0,' ',new Base[]{
																																		new CombinationLoop(' ',null,0,(char)VK.VK_BROWSER_STOP,null),
																																		new Combination('}',null,0,(char)VK.VK_BROWSER_STOP,null),
																																		new Normal(null,ParseException,0,' ',null)
																																	}),
																																	new Normal(null,ParseException,0,' ',null)
																																}),
																																new Normal(null,ParseException,0,' ',null)
																															}),
																															new Normal(null,ParseException,0,' ',null)
																														}),
																														new Normal(null,ParseException,0,' ',null)
																													}),
																													new Normal(null,ParseException,0,' ',null)
																												}),
																												new Normal(null,ParseException,0,' ',null)
																											}),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal(null,ParseException,0,' ',null)
																}),
																new Normal('C',null,0,' ',new Base[]{
																	new NormalLoop(' ',null,0,(char)VK.VK_C,null),
																	new Normal('}',null,0,(char)VK.VK_C,null),
																	new Normal('.',null,0,' ',new Base[]{
																		new Normal('C',null,0,' ',new Base[]{
																			new Normal('O',null,0,' ',new Base[]{
																				new Normal('M',null,0,' ',new Base[]{
																					new Normal('B',null,0,' ',new Base[]{
																						new Normal('I',null,0,' ',new Base[]{
																							new CombinationLoop(' ',null,0,(char)VK.VK_C,null),
																							new Combination('}',null,0,(char)VK.VK_C,null),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal('A',null,0,' ',new Base[]{
																		new Normal('N',null,0,' ',new Base[]{
																			new Normal('C',null,0,' ',new Base[]{
																				new Normal('E',null,0,' ',new Base[]{
																					new Normal('L',null,0,' ',new Base[]{
																						new NormalLoop(' ',null,0,(char)VK.VK_CANCEL,null),
																						new Normal('}',null,0,(char)VK.VK_CANCEL,null),
																						new Normal('.',null,0,' ',new Base[]{
																							new Normal('C',null,0,' ',new Base[]{
																								new Normal('O',null,0,' ',new Base[]{
																									new Normal('M',null,0,' ',new Base[]{
																										new Normal('B',null,0,' ',new Base[]{
																											new Normal('I',null,0,' ',new Base[]{
																												new CombinationLoop(' ',null,0,(char)VK.VK_CANCEL,null),
																												new Combination('}',null,0,(char)VK.VK_CANCEL,null),
																												new Normal(null,ParseException,0,' ',null)
																											}),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal('P',null,0,' ',new Base[]{
																			new Normal('I',null,0,' ',new Base[]{
																				new Normal('T',null,0,' ',new Base[]{
																					new Normal('A',null,0,' ',new Base[]{
																						new Normal('L',null,0,' ',new Base[]{
																							new NormalLoop(' ',null,0,(char)VK.VK_CAPITAL,null),
																							new Normal('}',null,0,(char)VK.VK_CAPITAL,null),
																							new Normal('.',null,0,' ',new Base[]{
																								new Normal('C',null,0,' ',new Base[]{
																									new Normal('O',null,0,' ',new Base[]{
																										new Normal('M',null,0,' ',new Base[]{
																											new Normal('B',null,0,' ',new Base[]{
																												new Normal('I',null,0,' ',new Base[]{
																													new CombinationLoop(' ',null,0,(char)VK.VK_CAPITAL,null),
																													new Combination('}',null,0,(char)VK.VK_CAPITAL,null),
																													new Normal(null,ParseException,0,' ',null)
																												}),
																												new Normal(null,ParseException,0,' ',null)
																											}),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal('L',null,0,' ',new Base[]{
																		new Normal('E',null,0,' ',new Base[]{
																			new Normal('A',null,0,' ',new Base[]{
																				new Normal('R',null,0,' ',new Base[]{
																					new NormalLoop(' ',null,0,(char)VK.VK_CLEAR,null),
																					new Normal('}',null,0,(char)VK.VK_CLEAR,null),
																					new Normal('.',null,0,' ',new Base[]{
																						new Normal('C',null,0,' ',new Base[]{
																							new Normal('O',null,0,' ',new Base[]{
																								new Normal('M',null,0,' ',new Base[]{
																									new Normal('B',null,0,' ',new Base[]{
																										new Normal('I',null,0,' ',new Base[]{
																											new CombinationLoop(' ',null,0,(char)VK.VK_CLEAR,null),
																											new Combination('}',null,0,(char)VK.VK_CLEAR,null),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal('O',null,0,' ',new Base[]{
																		new Normal('N',null,0,' ',new Base[]{
																			new Normal('T',null,0,' ',new Base[]{
																				new Normal('R',null,0,' ',new Base[]{
																					new Normal('O',null,0,' ',new Base[]{
																						new Normal('L',null,0,' ',new Base[]{
																							new NormalLoop(' ',null,0,(char)VK.VK_CONTROL,null),
																							new Normal('}',null,0,(char)VK.VK_CONTROL,null),
																							new Normal('.',null,0,' ',new Base[]{
																								new Normal('C',null,0,' ',new Base[]{
																									new Normal('O',null,0,' ',new Base[]{
																										new Normal('M',null,0,' ',new Base[]{
																											new Normal('B',null,0,' ',new Base[]{
																												new Normal('I',null,0,' ',new Base[]{
																													new CombinationLoop(' ',null,0,(char)VK.VK_CONTROL,null),
																													new Combination('}',null,0,(char)VK.VK_CONTROL,null),
																													new Normal(null,ParseException,0,' ',null)
																												}),
																												new Normal(null,ParseException,0,' ',null)
																											}),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('V',null,0,' ',new Base[]{
																				new Normal('E',null,0,' ',new Base[]{
																					new Normal('R',null,0,' ',new Base[]{
																						new Normal('T',null,0,' ',new Base[]{
																							new NormalLoop(' ',null,0,(char)VK.VK_CONVERT,null),
																							new Normal('}',null,0,(char)VK.VK_CONVERT,null),
																							new Normal('.',null,0,' ',new Base[]{
																								new Normal('C',null,0,' ',new Base[]{
																									new Normal('O',null,0,' ',new Base[]{
																										new Normal('M',null,0,' ',new Base[]{
																											new Normal('B',null,0,' ',new Base[]{
																												new Normal('I',null,0,' ',new Base[]{
																													new CombinationLoop(' ',null,0,(char)VK.VK_CONVERT,null),
																													new Combination('}',null,0,(char)VK.VK_CONVERT,null),
																													new Normal(null,ParseException,0,' ',null)
																												}),
																												new Normal(null,ParseException,0,' ',null)
																											}),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal('R',null,0,' ',new Base[]{
																		new Normal('S',null,0,' ',new Base[]{
																			new Normal('E',null,0,' ',new Base[]{
																				new Normal('L',null,0,' ',new Base[]{
																					new NormalLoop(' ',null,0,(char)VK.VK_CRSEL,null),
																					new Normal('}',null,0,(char)VK.VK_CRSEL,null),
																					new Normal('.',null,0,' ',new Base[]{
																						new Normal('C',null,0,' ',new Base[]{
																							new Normal('O',null,0,' ',new Base[]{
																								new Normal('M',null,0,' ',new Base[]{
																									new Normal('B',null,0,' ',new Base[]{
																										new Normal('I',null,0,' ',new Base[]{
																											new CombinationLoop(' ',null,0,(char)VK.VK_CRSEL,null),
																											new Combination('}',null,0,(char)VK.VK_CRSEL,null),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal(null,ParseException,0,' ',null)
																}),
																new Normal('D',null,0,' ',new Base[]{
																	new NormalLoop(' ',null,0,(char)VK.VK_D,null),
																	new Normal('}',null,0,(char)VK.VK_D,null),
																	new Normal('.',null,0,' ',new Base[]{
																		new Normal('C',null,0,' ',new Base[]{
																			new Normal('O',null,0,' ',new Base[]{
																				new Normal('M',null,0,' ',new Base[]{
																					new Normal('B',null,0,' ',new Base[]{
																						new Normal('I',null,0,' ',new Base[]{
																							new CombinationLoop(' ',null,0,(char)VK.VK_D,null),
																							new Combination('}',null,0,(char)VK.VK_D,null),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal('E',null,0,' ',new Base[]{
																		new Normal('C',null,0,' ',new Base[]{
																			new Normal('I',null,0,' ',new Base[]{
																				new Normal('M',null,0,' ',new Base[]{
																					new Normal('A',null,0,' ',new Base[]{
																						new Normal('L',null,0,' ',new Base[]{
																							new NormalLoop(' ',null,0,(char)VK.VK_DECIMAL,null),
																							new Normal('}',null,0,(char)VK.VK_DECIMAL,null),
																							new Normal('.',null,0,' ',new Base[]{
																								new Normal('C',null,0,' ',new Base[]{
																									new Normal('O',null,0,' ',new Base[]{
																										new Normal('M',null,0,' ',new Base[]{
																											new Normal('B',null,0,' ',new Base[]{
																												new Normal('I',null,0,' ',new Base[]{
																													new CombinationLoop(' ',null,0,(char)VK.VK_DECIMAL,null),
																													new Combination('}',null,0,(char)VK.VK_DECIMAL,null),
																													new Normal(null,ParseException,0,' ',null)
																												}),
																												new Normal(null,ParseException,0,' ',null)
																											}),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal('L',null,0,' ',new Base[]{
																			new Normal('E',null,0,' ',new Base[]{
																				new Normal('T',null,0,' ',new Base[]{
																					new Normal('E',null,0,' ',new Base[]{
																						new NormalLoop(' ',null,0,(char)VK.VK_DELETE,null),
																						new Normal('}',null,0,(char)VK.VK_DELETE,null),
																						new Normal('.',null,0,' ',new Base[]{
																							new Normal('C',null,0,' ',new Base[]{
																								new Normal('O',null,0,' ',new Base[]{
																									new Normal('M',null,0,' ',new Base[]{
																										new Normal('B',null,0,' ',new Base[]{
																											new Normal('I',null,0,' ',new Base[]{
																												new CombinationLoop(' ',null,0,(char)VK.VK_DELETE,null),
																												new Combination('}',null,0,(char)VK.VK_DELETE,null),
																												new Normal(null,ParseException,0,' ',null)
																											}),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal('I',null,0,' ',new Base[]{
																		new Normal('V',null,0,' ',new Base[]{
																			new Normal('I',null,0,' ',new Base[]{
																				new Normal('D',null,0,' ',new Base[]{
																					new Normal('E',null,0,' ',new Base[]{
																						new NormalLoop(' ',null,0,(char)VK.VK_DIVIDE,null),
																						new Normal('}',null,0,(char)VK.VK_DIVIDE,null),
																						new Normal('.',null,0,' ',new Base[]{
																							new Normal('C',null,0,' ',new Base[]{
																								new Normal('O',null,0,' ',new Base[]{
																									new Normal('M',null,0,' ',new Base[]{
																										new Normal('B',null,0,' ',new Base[]{
																											new Normal('I',null,0,' ',new Base[]{
																												new CombinationLoop(' ',null,0,(char)VK.VK_DIVIDE,null),
																												new Combination('}',null,0,(char)VK.VK_DIVIDE,null),
																												new Normal(null,ParseException,0,' ',null)
																											}),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal('O',null,0,' ',new Base[]{
																		new Normal('W',null,0,' ',new Base[]{
																			new Normal('N',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_DOWN,null),
																				new Normal('}',null,0,(char)VK.VK_DOWN,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_DOWN,null),
																										new Combination('}',null,0,(char)VK.VK_DOWN,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal(null,ParseException,0,' ',null)
																}),
																new Normal('E',null,0,' ',new Base[]{
																	new NormalLoop(' ',null,0,(char)VK.VK_E,null),
																	new Normal('}',null,0,(char)VK.VK_E,null),
																	new Normal('.',null,0,' ',new Base[]{
																		new Normal('C',null,0,' ',new Base[]{
																			new Normal('O',null,0,' ',new Base[]{
																				new Normal('M',null,0,' ',new Base[]{
																					new Normal('B',null,0,' ',new Base[]{
																						new Normal('I',null,0,' ',new Base[]{
																							new CombinationLoop(' ',null,0,(char)VK.VK_E,null),
																							new Combination('}',null,0,(char)VK.VK_E,null),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal('N',null,0,' ',new Base[]{
																		new Normal('D',null,0,' ',new Base[]{
																			new NormalLoop(' ',null,0,(char)VK.VK_END,null),
																			new Normal('}',null,0,(char)VK.VK_END,null),
																			new Normal('.',null,0,' ',new Base[]{
																				new Normal('C',null,0,' ',new Base[]{
																					new Normal('O',null,0,' ',new Base[]{
																						new Normal('M',null,0,' ',new Base[]{
																							new Normal('B',null,0,' ',new Base[]{
																								new Normal('I',null,0,' ',new Base[]{
																									new CombinationLoop(' ',null,0,(char)VK.VK_END,null),
																									new Combination('}',null,0,(char)VK.VK_END,null),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal('R',null,0,' ',new Base[]{
																		new Normal('E',null,0,' ',new Base[]{
																			new Normal('O',null,0,' ',new Base[]{
																				new Normal('F',null,0,' ',new Base[]{
																					new NormalLoop(' ',null,0,(char)VK.VK_EREOF,null),
																					new Normal('}',null,0,(char)VK.VK_EREOF,null),
																					new Normal('.',null,0,' ',new Base[]{
																						new Normal('C',null,0,' ',new Base[]{
																							new Normal('O',null,0,' ',new Base[]{
																								new Normal('M',null,0,' ',new Base[]{
																									new Normal('B',null,0,' ',new Base[]{
																										new Normal('I',null,0,' ',new Base[]{
																											new CombinationLoop(' ',null,0,(char)VK.VK_EREOF,null),
																											new Combination('}',null,0,(char)VK.VK_EREOF,null),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal('S',null,0,' ',new Base[]{
																		new Normal('C',null,0,' ',new Base[]{
																			new Normal('A',null,0,' ',new Base[]{
																				new Normal('P',null,0,' ',new Base[]{
																					new Normal('E',null,0,' ',new Base[]{
																						new NormalLoop(' ',null,0,(char)VK.VK_ESCAPE,null),
																						new Normal('}',null,0,(char)VK.VK_ESCAPE,null),
																						new Normal('.',null,0,' ',new Base[]{
																							new Normal('C',null,0,' ',new Base[]{
																								new Normal('O',null,0,' ',new Base[]{
																									new Normal('M',null,0,' ',new Base[]{
																										new Normal('B',null,0,' ',new Base[]{
																											new Normal('I',null,0,' ',new Base[]{
																												new CombinationLoop(' ',null,0,(char)VK.VK_ESCAPE,null),
																												new Combination('}',null,0,(char)VK.VK_ESCAPE,null),
																												new Normal(null,ParseException,0,' ',null)
																											}),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal('X',null,0,' ',new Base[]{
																		new Normal('E',null,0,' ',new Base[]{
																			new Normal('C',null,0,' ',new Base[]{
																				new Normal('U',null,0,' ',new Base[]{
																					new Normal('T',null,0,' ',new Base[]{
																						new Normal('E',null,0,' ',new Base[]{
																							new NormalLoop(' ',null,0,(char)VK.VK_EXECUTE,null),
																							new Normal('}',null,0,(char)VK.VK_EXECUTE,null),
																							new Normal('.',null,0,' ',new Base[]{
																								new Normal('C',null,0,' ',new Base[]{
																									new Normal('O',null,0,' ',new Base[]{
																										new Normal('M',null,0,' ',new Base[]{
																											new Normal('B',null,0,' ',new Base[]{
																												new Normal('I',null,0,' ',new Base[]{
																													new CombinationLoop(' ',null,0,(char)VK.VK_EXECUTE,null),
																													new Combination('}',null,0,(char)VK.VK_EXECUTE,null),
																													new Normal(null,ParseException,0,' ',null)
																												}),
																												new Normal(null,ParseException,0,' ',null)
																											}),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal('S',null,0,' ',new Base[]{
																			new Normal('E',null,0,' ',new Base[]{
																				new Normal('L',null,0,' ',new Base[]{
																					new NormalLoop(' ',null,0,(char)VK.VK_EXSEL,null),
																					new Normal('}',null,0,(char)VK.VK_EXSEL,null),
																					new Normal('.',null,0,' ',new Base[]{
																						new Normal('C',null,0,' ',new Base[]{
																							new Normal('O',null,0,' ',new Base[]{
																								new Normal('M',null,0,' ',new Base[]{
																									new Normal('B',null,0,' ',new Base[]{
																										new Normal('I',null,0,' ',new Base[]{
																											new CombinationLoop(' ',null,0,(char)VK.VK_EXSEL,null),
																											new Combination('}',null,0,(char)VK.VK_EXSEL,null),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal(null,ParseException,0,' ',null)
																}),
																new Normal('F',null,0,' ',new Base[]{
																	new NormalLoop(' ',null,0,(char)VK.VK_F,null),
																	new Normal('}',null,0,(char)VK.VK_F,null),
																	new Normal('.',null,0,' ',new Base[]{
																		new Normal('C',null,0,' ',new Base[]{
																			new Normal('O',null,0,' ',new Base[]{
																				new Normal('M',null,0,' ',new Base[]{
																					new Normal('B',null,0,' ',new Base[]{
																						new Normal('I',null,0,' ',new Base[]{
																							new CombinationLoop(' ',null,0,(char)VK.VK_F,null),
																							new Combination('}',null,0,(char)VK.VK_F,null),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal('1',null,0,' ',new Base[]{
																		new NormalLoop(' ',null,0,(char)VK.VK_F1,null),
																		new Normal('}',null,0,(char)VK.VK_F1,null),
																		new Normal('.',null,0,' ',new Base[]{
																			new Normal('C',null,0,' ',new Base[]{
																				new Normal('O',null,0,' ',new Base[]{
																					new Normal('M',null,0,' ',new Base[]{
																						new Normal('B',null,0,' ',new Base[]{
																							new Normal('I',null,0,' ',new Base[]{
																								new CombinationLoop(' ',null,0,(char)VK.VK_F1,null),
																								new Combination('}',null,0,(char)VK.VK_F1,null),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal('0',null,0,' ',new Base[]{
																			new NormalLoop(' ',null,0,(char)VK.VK_F10,null),
																			new Normal('}',null,0,(char)VK.VK_F10,null),
																			new Normal('.',null,0,' ',new Base[]{
																				new Normal('C',null,0,' ',new Base[]{
																					new Normal('O',null,0,' ',new Base[]{
																						new Normal('M',null,0,' ',new Base[]{
																							new Normal('B',null,0,' ',new Base[]{
																								new Normal('I',null,0,' ',new Base[]{
																									new CombinationLoop(' ',null,0,(char)VK.VK_F10,null),
																									new Combination('}',null,0,(char)VK.VK_F10,null),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal('1',null,0,' ',new Base[]{
																			new NormalLoop(' ',null,0,(char)VK.VK_F11,null),
																			new Normal('}',null,0,(char)VK.VK_F11,null),
																			new Normal('.',null,0,' ',new Base[]{
																				new Normal('C',null,0,' ',new Base[]{
																					new Normal('O',null,0,' ',new Base[]{
																						new Normal('M',null,0,' ',new Base[]{
																							new Normal('B',null,0,' ',new Base[]{
																								new Normal('I',null,0,' ',new Base[]{
																									new CombinationLoop(' ',null,0,(char)VK.VK_F11,null),
																									new Combination('}',null,0,(char)VK.VK_F11,null),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal('2',null,0,' ',new Base[]{
																			new NormalLoop(' ',null,0,(char)VK.VK_F12,null),
																			new Normal('}',null,0,(char)VK.VK_F12,null),
																			new Normal('.',null,0,' ',new Base[]{
																				new Normal('C',null,0,' ',new Base[]{
																					new Normal('O',null,0,' ',new Base[]{
																						new Normal('M',null,0,' ',new Base[]{
																							new Normal('B',null,0,' ',new Base[]{
																								new Normal('I',null,0,' ',new Base[]{
																									new CombinationLoop(' ',null,0,(char)VK.VK_F12,null),
																									new Combination('}',null,0,(char)VK.VK_F12,null),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal('3',null,0,' ',new Base[]{
																			new NormalLoop(' ',null,0,(char)VK.VK_F13,null),
																			new Normal('}',null,0,(char)VK.VK_F13,null),
																			new Normal('.',null,0,' ',new Base[]{
																				new Normal('C',null,0,' ',new Base[]{
																					new Normal('O',null,0,' ',new Base[]{
																						new Normal('M',null,0,' ',new Base[]{
																							new Normal('B',null,0,' ',new Base[]{
																								new Normal('I',null,0,' ',new Base[]{
																									new CombinationLoop(' ',null,0,(char)VK.VK_F13,null),
																									new Combination('}',null,0,(char)VK.VK_F13,null),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal('4',null,0,' ',new Base[]{
																			new NormalLoop(' ',null,0,(char)VK.VK_F14,null),
																			new Normal('}',null,0,(char)VK.VK_F14,null),
																			new Normal('.',null,0,' ',new Base[]{
																				new Normal('C',null,0,' ',new Base[]{
																					new Normal('O',null,0,' ',new Base[]{
																						new Normal('M',null,0,' ',new Base[]{
																							new Normal('B',null,0,' ',new Base[]{
																								new Normal('I',null,0,' ',new Base[]{
																									new CombinationLoop(' ',null,0,(char)VK.VK_F14,null),
																									new Combination('}',null,0,(char)VK.VK_F14,null),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal('5',null,0,' ',new Base[]{
																			new NormalLoop(' ',null,0,(char)VK.VK_F15,null),
																			new Normal('}',null,0,(char)VK.VK_F15,null),
																			new Normal('.',null,0,' ',new Base[]{
																				new Normal('C',null,0,' ',new Base[]{
																					new Normal('O',null,0,' ',new Base[]{
																						new Normal('M',null,0,' ',new Base[]{
																							new Normal('B',null,0,' ',new Base[]{
																								new Normal('I',null,0,' ',new Base[]{
																									new CombinationLoop(' ',null,0,(char)VK.VK_F15,null),
																									new Combination('}',null,0,(char)VK.VK_F15,null),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal('6',null,0,' ',new Base[]{
																			new NormalLoop(' ',null,0,(char)VK.VK_F16,null),
																			new Normal('}',null,0,(char)VK.VK_F16,null),
																			new Normal('.',null,0,' ',new Base[]{
																				new Normal('C',null,0,' ',new Base[]{
																					new Normal('O',null,0,' ',new Base[]{
																						new Normal('M',null,0,' ',new Base[]{
																							new Normal('B',null,0,' ',new Base[]{
																								new Normal('I',null,0,' ',new Base[]{
																									new CombinationLoop(' ',null,0,(char)VK.VK_F16,null),
																									new Combination('}',null,0,(char)VK.VK_F16,null),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal('7',null,0,' ',new Base[]{
																			new NormalLoop(' ',null,0,(char)VK.VK_F17,null),
																			new Normal('}',null,0,(char)VK.VK_F17,null),
																			new Normal('.',null,0,' ',new Base[]{
																				new Normal('C',null,0,' ',new Base[]{
																					new Normal('O',null,0,' ',new Base[]{
																						new Normal('M',null,0,' ',new Base[]{
																							new Normal('B',null,0,' ',new Base[]{
																								new Normal('I',null,0,' ',new Base[]{
																									new CombinationLoop(' ',null,0,(char)VK.VK_F17,null),
																									new Combination('}',null,0,(char)VK.VK_F17,null),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal('8',null,0,' ',new Base[]{
																			new NormalLoop(' ',null,0,(char)VK.VK_F18,null),
																			new Normal('}',null,0,(char)VK.VK_F18,null),
																			new Normal('.',null,0,' ',new Base[]{
																				new Normal('C',null,0,' ',new Base[]{
																					new Normal('O',null,0,' ',new Base[]{
																						new Normal('M',null,0,' ',new Base[]{
																							new Normal('B',null,0,' ',new Base[]{
																								new Normal('I',null,0,' ',new Base[]{
																									new CombinationLoop(' ',null,0,(char)VK.VK_F18,null),
																									new Combination('}',null,0,(char)VK.VK_F18,null),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal('9',null,0,' ',new Base[]{
																			new NormalLoop(' ',null,0,(char)VK.VK_F19,null),
																			new Normal('}',null,0,(char)VK.VK_F19,null),
																			new Normal('.',null,0,' ',new Base[]{
																				new Normal('C',null,0,' ',new Base[]{
																					new Normal('O',null,0,' ',new Base[]{
																						new Normal('M',null,0,' ',new Base[]{
																							new Normal('B',null,0,' ',new Base[]{
																								new Normal('I',null,0,' ',new Base[]{
																									new CombinationLoop(' ',null,0,(char)VK.VK_F19,null),
																									new Combination('}',null,0,(char)VK.VK_F19,null),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal('2',null,0,' ',new Base[]{
																		new NormalLoop(' ',null,0,(char)VK.VK_F2,null),
																		new Normal('}',null,0,(char)VK.VK_F2,null),
																		new Normal('.',null,0,' ',new Base[]{
																			new Normal('C',null,0,' ',new Base[]{
																				new Normal('O',null,0,' ',new Base[]{
																					new Normal('M',null,0,' ',new Base[]{
																						new Normal('B',null,0,' ',new Base[]{
																							new Normal('I',null,0,' ',new Base[]{
																								new CombinationLoop(' ',null,0,(char)VK.VK_F2,null),
																								new Combination('}',null,0,(char)VK.VK_F2,null),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal('0',null,0,' ',new Base[]{
																			new NormalLoop(' ',null,0,(char)VK.VK_F20,null),
																			new Normal('}',null,0,(char)VK.VK_F20,null),
																			new Normal('.',null,0,' ',new Base[]{
																				new Normal('C',null,0,' ',new Base[]{
																					new Normal('O',null,0,' ',new Base[]{
																						new Normal('M',null,0,' ',new Base[]{
																							new Normal('B',null,0,' ',new Base[]{
																								new Normal('I',null,0,' ',new Base[]{
																									new CombinationLoop(' ',null,0,(char)VK.VK_F20,null),
																									new Combination('}',null,0,(char)VK.VK_F20,null),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal('1',null,0,' ',new Base[]{
																			new NormalLoop(' ',null,0,(char)VK.VK_F21,null),
																			new Normal('}',null,0,(char)VK.VK_F21,null),
																			new Normal('.',null,0,' ',new Base[]{
																				new Normal('C',null,0,' ',new Base[]{
																					new Normal('O',null,0,' ',new Base[]{
																						new Normal('M',null,0,' ',new Base[]{
																							new Normal('B',null,0,' ',new Base[]{
																								new Normal('I',null,0,' ',new Base[]{
																									new CombinationLoop(' ',null,0,(char)VK.VK_F21,null),
																									new Combination('}',null,0,(char)VK.VK_F21,null),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal('2',null,0,' ',new Base[]{
																			new NormalLoop(' ',null,0,(char)VK.VK_F22,null),
																			new Normal('}',null,0,(char)VK.VK_F22,null),
																			new Normal('.',null,0,' ',new Base[]{
																				new Normal('C',null,0,' ',new Base[]{
																					new Normal('O',null,0,' ',new Base[]{
																						new Normal('M',null,0,' ',new Base[]{
																							new Normal('B',null,0,' ',new Base[]{
																								new Normal('I',null,0,' ',new Base[]{
																									new CombinationLoop(' ',null,0,(char)VK.VK_F22,null),
																									new Combination('}',null,0,(char)VK.VK_F22,null),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal('3',null,0,' ',new Base[]{
																			new NormalLoop(' ',null,0,(char)VK.VK_F23,null),
																			new Normal('}',null,0,(char)VK.VK_F23,null),
																			new Normal('.',null,0,' ',new Base[]{
																				new Normal('C',null,0,' ',new Base[]{
																					new Normal('O',null,0,' ',new Base[]{
																						new Normal('M',null,0,' ',new Base[]{
																							new Normal('B',null,0,' ',new Base[]{
																								new Normal('I',null,0,' ',new Base[]{
																									new CombinationLoop(' ',null,0,(char)VK.VK_F23,null),
																									new Combination('}',null,0,(char)VK.VK_F23,null),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal('4',null,0,' ',new Base[]{
																			new NormalLoop(' ',null,0,(char)VK.VK_F24,null),
																			new Normal('}',null,0,(char)VK.VK_F24,null),
																			new Normal('.',null,0,' ',new Base[]{
																				new Normal('C',null,0,' ',new Base[]{
																					new Normal('O',null,0,' ',new Base[]{
																						new Normal('M',null,0,' ',new Base[]{
																							new Normal('B',null,0,' ',new Base[]{
																								new Normal('I',null,0,' ',new Base[]{
																									new CombinationLoop(' ',null,0,(char)VK.VK_F24,null),
																									new Combination('}',null,0,(char)VK.VK_F24,null),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal('3',null,0,' ',new Base[]{
																		new NormalLoop(' ',null,0,(char)VK.VK_F3,null),
																		new Normal('}',null,0,(char)VK.VK_F3,null),
																		new Normal('.',null,0,' ',new Base[]{
																			new Normal('C',null,0,' ',new Base[]{
																				new Normal('O',null,0,' ',new Base[]{
																					new Normal('M',null,0,' ',new Base[]{
																						new Normal('B',null,0,' ',new Base[]{
																							new Normal('I',null,0,' ',new Base[]{
																								new CombinationLoop(' ',null,0,(char)VK.VK_F3,null),
																								new Combination('}',null,0,(char)VK.VK_F3,null),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal('4',null,0,' ',new Base[]{
																		new NormalLoop(' ',null,0,(char)VK.VK_F4,null),
																		new Normal('}',null,0,(char)VK.VK_F4,null),
																		new Normal('.',null,0,' ',new Base[]{
																			new Normal('C',null,0,' ',new Base[]{
																				new Normal('O',null,0,' ',new Base[]{
																					new Normal('M',null,0,' ',new Base[]{
																						new Normal('B',null,0,' ',new Base[]{
																							new Normal('I',null,0,' ',new Base[]{
																								new CombinationLoop(' ',null,0,(char)VK.VK_F4,null),
																								new Combination('}',null,0,(char)VK.VK_F4,null),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal('5',null,0,' ',new Base[]{
																		new NormalLoop(' ',null,0,(char)VK.VK_F5,null),
																		new Normal('}',null,0,(char)VK.VK_F5,null),
																		new Normal('.',null,0,' ',new Base[]{
																			new Normal('C',null,0,' ',new Base[]{
																				new Normal('O',null,0,' ',new Base[]{
																					new Normal('M',null,0,' ',new Base[]{
																						new Normal('B',null,0,' ',new Base[]{
																							new Normal('I',null,0,' ',new Base[]{
																								new CombinationLoop(' ',null,0,(char)VK.VK_F5,null),
																								new Combination('}',null,0,(char)VK.VK_F5,null),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal('6',null,0,' ',new Base[]{
																		new NormalLoop(' ',null,0,(char)VK.VK_F6,null),
																		new Normal('}',null,0,(char)VK.VK_F6,null),
																		new Normal('.',null,0,' ',new Base[]{
																			new Normal('C',null,0,' ',new Base[]{
																				new Normal('O',null,0,' ',new Base[]{
																					new Normal('M',null,0,' ',new Base[]{
																						new Normal('B',null,0,' ',new Base[]{
																							new Normal('I',null,0,' ',new Base[]{
																								new CombinationLoop(' ',null,0,(char)VK.VK_F6,null),
																								new Combination('}',null,0,(char)VK.VK_F6,null),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal('7',null,0,' ',new Base[]{
																		new NormalLoop(' ',null,0,(char)VK.VK_F7,null),
																		new Normal('}',null,0,(char)VK.VK_F7,null),
																		new Normal('.',null,0,' ',new Base[]{
																			new Normal('C',null,0,' ',new Base[]{
																				new Normal('O',null,0,' ',new Base[]{
																					new Normal('M',null,0,' ',new Base[]{
																						new Normal('B',null,0,' ',new Base[]{
																							new Normal('I',null,0,' ',new Base[]{
																								new CombinationLoop(' ',null,0,(char)VK.VK_F7,null),
																								new Combination('}',null,0,(char)VK.VK_F7,null),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal('8',null,0,' ',new Base[]{
																		new NormalLoop(' ',null,0,(char)VK.VK_F8,null),
																		new Normal('}',null,0,(char)VK.VK_F8,null),
																		new Normal('.',null,0,' ',new Base[]{
																			new Normal('C',null,0,' ',new Base[]{
																				new Normal('O',null,0,' ',new Base[]{
																					new Normal('M',null,0,' ',new Base[]{
																						new Normal('B',null,0,' ',new Base[]{
																							new Normal('I',null,0,' ',new Base[]{
																								new CombinationLoop(' ',null,0,(char)VK.VK_F8,null),
																								new Combination('}',null,0,(char)VK.VK_F8,null),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal('9',null,0,' ',new Base[]{
																		new NormalLoop(' ',null,0,(char)VK.VK_F9,null),
																		new Normal('}',null,0,(char)VK.VK_F9,null),
																		new Normal('.',null,0,' ',new Base[]{
																			new Normal('C',null,0,' ',new Base[]{
																				new Normal('O',null,0,' ',new Base[]{
																					new Normal('M',null,0,' ',new Base[]{
																						new Normal('B',null,0,' ',new Base[]{
																							new Normal('I',null,0,' ',new Base[]{
																								new CombinationLoop(' ',null,0,(char)VK.VK_F9,null),
																								new Combination('}',null,0,(char)VK.VK_F9,null),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal('I',null,0,' ',new Base[]{
																		new Normal('N',null,0,' ',new Base[]{
																			new Normal('A',null,0,' ',new Base[]{
																				new Normal('L',null,0,' ',new Base[]{
																					new NormalLoop(' ',null,0,(char)VK.VK_FINAL,null),
																					new Normal('}',null,0,(char)VK.VK_FINAL,null),
																					new Normal('.',null,0,' ',new Base[]{
																						new Normal('C',null,0,' ',new Base[]{
																							new Normal('O',null,0,' ',new Base[]{
																								new Normal('M',null,0,' ',new Base[]{
																									new Normal('B',null,0,' ',new Base[]{
																										new Normal('I',null,0,' ',new Base[]{
																											new CombinationLoop(' ',null,0,(char)VK.VK_FINAL,null),
																											new Combination('}',null,0,(char)VK.VK_FINAL,null),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal(null,ParseException,0,' ',null)
																}),
																new Normal('G',null,0,' ',new Base[]{
																	new NormalLoop(' ',null,0,(char)VK.VK_G,null),
																	new Normal('}',null,0,(char)VK.VK_G,null),
																	new Normal('.',null,0,' ',new Base[]{
																		new Normal('C',null,0,' ',new Base[]{
																			new Normal('O',null,0,' ',new Base[]{
																				new Normal('M',null,0,' ',new Base[]{
																					new Normal('B',null,0,' ',new Base[]{
																						new Normal('I',null,0,' ',new Base[]{
																							new CombinationLoop(' ',null,0,(char)VK.VK_G,null),
																							new Combination('}',null,0,(char)VK.VK_G,null),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal(null,ParseException,0,' ',null)
																}),
																new Normal('H',null,0,' ',new Base[]{
																	new NormalLoop(' ',null,0,(char)VK.VK_H,null),
																	new Normal('}',null,0,(char)VK.VK_H,null),
																	new Normal('.',null,0,' ',new Base[]{
																		new Normal('C',null,0,' ',new Base[]{
																			new Normal('O',null,0,' ',new Base[]{
																				new Normal('M',null,0,' ',new Base[]{
																					new Normal('B',null,0,' ',new Base[]{
																						new Normal('I',null,0,' ',new Base[]{
																							new CombinationLoop(' ',null,0,(char)VK.VK_H,null),
																							new Combination('}',null,0,(char)VK.VK_H,null),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal('A',null,0,' ',new Base[]{
																		new Normal('N',null,0,' ',new Base[]{
																			new Normal('G',null,0,' ',new Base[]{
																				new Normal('U',null,0,' ',new Base[]{
																					new Normal('E',null,0,' ',new Base[]{
																						new Normal('L',null,0,' ',new Base[]{
																							new NormalLoop(' ',null,0,(char)VK.VK_HANGUEL,null),
																							new Normal('}',null,0,(char)VK.VK_HANGUEL,null),
																							new Normal('.',null,0,' ',new Base[]{
																								new Normal('C',null,0,' ',new Base[]{
																									new Normal('O',null,0,' ',new Base[]{
																										new Normal('M',null,0,' ',new Base[]{
																											new Normal('B',null,0,' ',new Base[]{
																												new Normal('I',null,0,' ',new Base[]{
																													new CombinationLoop(' ',null,0,(char)VK.VK_HANGUEL,null),
																													new Combination('}',null,0,(char)VK.VK_HANGUEL,null),
																													new Normal(null,ParseException,0,' ',null)
																												}),
																												new Normal(null,ParseException,0,' ',null)
																											}),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal('L',null,0,' ',new Base[]{
																						new NormalLoop(' ',null,0,(char)VK.VK_HANGUL,null),
																						new Normal('}',null,0,(char)VK.VK_HANGUL,null),
																						new Normal('.',null,0,' ',new Base[]{
																							new Normal('C',null,0,' ',new Base[]{
																								new Normal('O',null,0,' ',new Base[]{
																									new Normal('M',null,0,' ',new Base[]{
																										new Normal('B',null,0,' ',new Base[]{
																											new Normal('I',null,0,' ',new Base[]{
																												new CombinationLoop(' ',null,0,(char)VK.VK_HANGUL,null),
																												new Combination('}',null,0,(char)VK.VK_HANGUL,null),
																												new Normal(null,ParseException,0,' ',null)
																											}),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('J',null,0,' ',new Base[]{
																				new Normal('A',null,0,' ',new Base[]{
																					new NormalLoop(' ',null,0,(char)VK.VK_HANJA,null),
																					new Normal('}',null,0,(char)VK.VK_HANJA,null),
																					new Normal('.',null,0,' ',new Base[]{
																						new Normal('C',null,0,' ',new Base[]{
																							new Normal('O',null,0,' ',new Base[]{
																								new Normal('M',null,0,' ',new Base[]{
																									new Normal('B',null,0,' ',new Base[]{
																										new Normal('I',null,0,' ',new Base[]{
																											new CombinationLoop(' ',null,0,(char)VK.VK_HANJA,null),
																											new Combination('}',null,0,(char)VK.VK_HANJA,null),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal('E',null,0,' ',new Base[]{
																		new Normal('L',null,0,' ',new Base[]{
																			new Normal('P',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_HELP,null),
																				new Normal('}',null,0,(char)VK.VK_HELP,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_HELP,null),
																										new Combination('}',null,0,(char)VK.VK_HELP,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal('O',null,0,' ',new Base[]{
																		new Normal('M',null,0,' ',new Base[]{
																			new Normal('E',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_HOME,null),
																				new Normal('}',null,0,(char)VK.VK_HOME,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_HOME,null),
																										new Combination('}',null,0,(char)VK.VK_HOME,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal(null,ParseException,0,' ',null)
																}),
																new Normal('I',null,0,' ',new Base[]{
																	new NormalLoop(' ',null,0,(char)VK.VK_I,null),
																	new Normal('}',null,0,(char)VK.VK_I,null),
																	new Normal('.',null,0,' ',new Base[]{
																		new Normal('C',null,0,' ',new Base[]{
																			new Normal('O',null,0,' ',new Base[]{
																				new Normal('M',null,0,' ',new Base[]{
																					new Normal('B',null,0,' ',new Base[]{
																						new Normal('I',null,0,' ',new Base[]{
																							new CombinationLoop(' ',null,0,(char)VK.VK_I,null),
																							new Combination('}',null,0,(char)VK.VK_I,null),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal('N',null,0,' ',new Base[]{
																		new Normal('S',null,0,' ',new Base[]{
																			new Normal('E',null,0,' ',new Base[]{
																				new Normal('R',null,0,' ',new Base[]{
																					new Normal('T',null,0,' ',new Base[]{
																						new NormalLoop(' ',null,0,(char)VK.VK_INSERT,null),
																						new Normal('}',null,0,(char)VK.VK_INSERT,null),
																						new Normal('.',null,0,' ',new Base[]{
																							new Normal('C',null,0,' ',new Base[]{
																								new Normal('O',null,0,' ',new Base[]{
																									new Normal('M',null,0,' ',new Base[]{
																										new Normal('B',null,0,' ',new Base[]{
																											new Normal('I',null,0,' ',new Base[]{
																												new CombinationLoop(' ',null,0,(char)VK.VK_INSERT,null),
																												new Combination('}',null,0,(char)VK.VK_INSERT,null),
																												new Normal(null,ParseException,0,' ',null)
																											}),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal(null,ParseException,0,' ',null)
																}),
																new Normal('J',null,0,' ',new Base[]{
																	new NormalLoop(' ',null,0,(char)VK.VK_J,null),
																	new Normal('}',null,0,(char)VK.VK_J,null),
																	new Normal('.',null,0,' ',new Base[]{
																		new Normal('C',null,0,' ',new Base[]{
																			new Normal('O',null,0,' ',new Base[]{
																				new Normal('M',null,0,' ',new Base[]{
																					new Normal('B',null,0,' ',new Base[]{
																						new Normal('I',null,0,' ',new Base[]{
																							new CombinationLoop(' ',null,0,(char)VK.VK_J,null),
																							new Combination('}',null,0,(char)VK.VK_J,null),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal('U',null,0,' ',new Base[]{
																		new Normal('N',null,0,' ',new Base[]{
																			new Normal('J',null,0,' ',new Base[]{
																				new Normal('A',null,0,' ',new Base[]{
																					new NormalLoop(' ',null,0,(char)VK.VK_JUNJA,null),
																					new Normal('}',null,0,(char)VK.VK_JUNJA,null),
																					new Normal('.',null,0,' ',new Base[]{
																						new Normal('C',null,0,' ',new Base[]{
																							new Normal('O',null,0,' ',new Base[]{
																								new Normal('M',null,0,' ',new Base[]{
																									new Normal('B',null,0,' ',new Base[]{
																										new Normal('I',null,0,' ',new Base[]{
																											new CombinationLoop(' ',null,0,(char)VK.VK_JUNJA,null),
																											new Combination('}',null,0,(char)VK.VK_JUNJA,null),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal(null,ParseException,0,' ',null)
																}),
																new Normal('K',null,0,' ',new Base[]{
																	new NormalLoop(' ',null,0,(char)VK.VK_K,null),
																	new Normal('}',null,0,(char)VK.VK_K,null),
																	new Normal('.',null,0,' ',new Base[]{
																		new Normal('C',null,0,' ',new Base[]{
																			new Normal('O',null,0,' ',new Base[]{
																				new Normal('M',null,0,' ',new Base[]{
																					new Normal('B',null,0,' ',new Base[]{
																						new Normal('I',null,0,' ',new Base[]{
																							new CombinationLoop(' ',null,0,(char)VK.VK_K,null),
																							new Combination('}',null,0,(char)VK.VK_K,null),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal('A',null,0,' ',new Base[]{
																		new Normal('N',null,0,' ',new Base[]{
																			new Normal('A',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_KANA,null),
																				new Normal('}',null,0,(char)VK.VK_KANA,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_KANA,null),
																										new Combination('}',null,0,(char)VK.VK_KANA,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('J',null,0,' ',new Base[]{
																				new Normal('I',null,0,' ',new Base[]{
																					new NormalLoop(' ',null,0,(char)VK.VK_KANJI,null),
																					new Normal('}',null,0,(char)VK.VK_KANJI,null),
																					new Normal('.',null,0,' ',new Base[]{
																						new Normal('C',null,0,' ',new Base[]{
																							new Normal('O',null,0,' ',new Base[]{
																								new Normal('M',null,0,' ',new Base[]{
																									new Normal('B',null,0,' ',new Base[]{
																										new Normal('I',null,0,' ',new Base[]{
																											new CombinationLoop(' ',null,0,(char)VK.VK_KANJI,null),
																											new Combination('}',null,0,(char)VK.VK_KANJI,null),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal(null,ParseException,0,' ',null)
																}),
																new Normal('L',null,0,' ',new Base[]{
																	new NormalLoop(' ',null,0,(char)VK.VK_L,null),
																	new Normal('}',null,0,(char)VK.VK_L,null),
																	new Normal('.',null,0,' ',new Base[]{
																		new Normal('C',null,0,' ',new Base[]{
																			new Normal('O',null,0,' ',new Base[]{
																				new Normal('M',null,0,' ',new Base[]{
																					new Normal('B',null,0,' ',new Base[]{
																						new Normal('I',null,0,' ',new Base[]{
																							new CombinationLoop(' ',null,0,(char)VK.VK_L,null),
																							new Combination('}',null,0,(char)VK.VK_L,null),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal('A',null,0,' ',new Base[]{
																		new Normal('U',null,0,' ',new Base[]{
																			new Normal('N',null,0,' ',new Base[]{
																				new Normal('C',null,0,' ',new Base[]{
																					new Normal('H',null,0,' ',new Base[]{
																						new Normal('_',null,0,' ',new Base[]{
																							new Normal('A',null,0,' ',new Base[]{
																								new Normal('P',null,0,' ',new Base[]{
																									new Normal('P',null,0,' ',new Base[]{
																										new Normal('1',null,0,' ',new Base[]{
																											new NormalLoop(' ',null,0,(char)VK.VK_LAUNCH_APP1,null),
																											new Normal('}',null,0,(char)VK.VK_LAUNCH_APP1,null),
																											new Normal('.',null,0,' ',new Base[]{
																												new Normal('C',null,0,' ',new Base[]{
																													new Normal('O',null,0,' ',new Base[]{
																														new Normal('M',null,0,' ',new Base[]{
																															new Normal('B',null,0,' ',new Base[]{
																																new Normal('I',null,0,' ',new Base[]{
																																	new CombinationLoop(' ',null,0,(char)VK.VK_LAUNCH_APP1,null),
																																	new Combination('}',null,0,(char)VK.VK_LAUNCH_APP1,null),
																																	new Normal(null,ParseException,0,' ',null)
																																}),
																																new Normal(null,ParseException,0,' ',null)
																															}),
																															new Normal(null,ParseException,0,' ',null)
																														}),
																														new Normal(null,ParseException,0,' ',null)
																													}),
																													new Normal(null,ParseException,0,' ',null)
																												}),
																												new Normal(null,ParseException,0,' ',null)
																											}),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal('2',null,0,' ',new Base[]{
																											new NormalLoop(' ',null,0,(char)VK.VK_LAUNCH_APP2,null),
																											new Normal('}',null,0,(char)VK.VK_LAUNCH_APP2,null),
																											new Normal('.',null,0,' ',new Base[]{
																												new Normal('C',null,0,' ',new Base[]{
																													new Normal('O',null,0,' ',new Base[]{
																														new Normal('M',null,0,' ',new Base[]{
																															new Normal('B',null,0,' ',new Base[]{
																																new Normal('I',null,0,' ',new Base[]{
																																	new CombinationLoop(' ',null,0,(char)VK.VK_LAUNCH_APP2,null),
																																	new Combination('}',null,0,(char)VK.VK_LAUNCH_APP2,null),
																																	new Normal(null,ParseException,0,' ',null)
																																}),
																																new Normal(null,ParseException,0,' ',null)
																															}),
																															new Normal(null,ParseException,0,' ',null)
																														}),
																														new Normal(null,ParseException,0,' ',null)
																													}),
																													new Normal(null,ParseException,0,' ',null)
																												}),
																												new Normal(null,ParseException,0,' ',null)
																											}),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('A',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new Normal('L',null,0,' ',new Base[]{
																											new NormalLoop(' ',null,0,(char)VK.VK_LAUNCH_MAIL,null),
																											new Normal('}',null,0,(char)VK.VK_LAUNCH_MAIL,null),
																											new Normal('.',null,0,' ',new Base[]{
																												new Normal('C',null,0,' ',new Base[]{
																													new Normal('O',null,0,' ',new Base[]{
																														new Normal('M',null,0,' ',new Base[]{
																															new Normal('B',null,0,' ',new Base[]{
																																new Normal('I',null,0,' ',new Base[]{
																																	new CombinationLoop(' ',null,0,(char)VK.VK_LAUNCH_MAIL,null),
																																	new Combination('}',null,0,(char)VK.VK_LAUNCH_MAIL,null),
																																	new Normal(null,ParseException,0,' ',null)
																																}),
																																new Normal(null,ParseException,0,' ',null)
																															}),
																															new Normal(null,ParseException,0,' ',null)
																														}),
																														new Normal(null,ParseException,0,' ',null)
																													}),
																													new Normal(null,ParseException,0,' ',null)
																												}),
																												new Normal(null,ParseException,0,' ',null)
																											}),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal('E',null,0,' ',new Base[]{
																									new Normal('D',null,0,' ',new Base[]{
																										new Normal('I',null,0,' ',new Base[]{
																											new Normal('A',null,0,' ',new Base[]{
																												new Normal('_',null,0,' ',new Base[]{
																													new Normal('S',null,0,' ',new Base[]{
																														new Normal('E',null,0,' ',new Base[]{
																															new Normal('L',null,0,' ',new Base[]{
																																new Normal('E',null,0,' ',new Base[]{
																																	new Normal('C',null,0,' ',new Base[]{
																																		new Normal('T',null,0,' ',new Base[]{
																																			new NormalLoop(' ',null,0,(char)VK.VK_LAUNCH_MEDIA_SELECT,null),
																																			new Normal('}',null,0,(char)VK.VK_LAUNCH_MEDIA_SELECT,null),
																																			new Normal('.',null,0,' ',new Base[]{
																																				new Normal('C',null,0,' ',new Base[]{
																																					new Normal('O',null,0,' ',new Base[]{
																																						new Normal('M',null,0,' ',new Base[]{
																																							new Normal('B',null,0,' ',new Base[]{
																																								new Normal('I',null,0,' ',new Base[]{
																																									new CombinationLoop(' ',null,0,(char)VK.VK_LAUNCH_MEDIA_SELECT,null),
																																									new Combination('}',null,0,(char)VK.VK_LAUNCH_MEDIA_SELECT,null),
																																									new Normal(null,ParseException,0,' ',null)
																																								}),
																																								new Normal(null,ParseException,0,' ',null)
																																							}),
																																							new Normal(null,ParseException,0,' ',null)
																																						}),
																																						new Normal(null,ParseException,0,' ',null)
																																					}),
																																					new Normal(null,ParseException,0,' ',null)
																																				}),
																																				new Normal(null,ParseException,0,' ',null)
																																			}),
																																			new Normal(null,ParseException,0,' ',null)
																																		}),
																																		new Normal(null,ParseException,0,' ',null)
																																	}),
																																	new Normal(null,ParseException,0,' ',null)
																																}),
																																new Normal(null,ParseException,0,' ',null)
																															}),
																															new Normal(null,ParseException,0,' ',null)
																														}),
																														new Normal(null,ParseException,0,' ',null)
																													}),
																													new Normal(null,ParseException,0,' ',null)
																												}),
																												new Normal(null,ParseException,0,' ',null)
																											}),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal('B',null,0,' ',new Base[]{
																		new Normal('U',null,0,' ',new Base[]{
																			new Normal('T',null,0,' ',new Base[]{
																				new Normal('T',null,0,' ',new Base[]{
																					new Normal('O',null,0,' ',new Base[]{
																						new Normal('N',null,0,' ',new Base[]{
																							new NormalLoop(' ',null,0,(char)VK.VK_LBUTTON,null),
																							new Normal('}',null,0,(char)VK.VK_LBUTTON,null),
																							new Normal('.',null,0,' ',new Base[]{
																								new Normal('C',null,0,' ',new Base[]{
																									new Normal('O',null,0,' ',new Base[]{
																										new Normal('M',null,0,' ',new Base[]{
																											new Normal('B',null,0,' ',new Base[]{
																												new Normal('I',null,0,' ',new Base[]{
																													new CombinationLoop(' ',null,0,(char)VK.VK_LBUTTON,null),
																													new Combination('}',null,0,(char)VK.VK_LBUTTON,null),
																													new Normal(null,ParseException,0,' ',null)
																												}),
																												new Normal(null,ParseException,0,' ',null)
																											}),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal('C',null,0,' ',new Base[]{
																		new Normal('O',null,0,' ',new Base[]{
																			new Normal('N',null,0,' ',new Base[]{
																				new Normal('T',null,0,' ',new Base[]{
																					new Normal('R',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('L',null,0,' ',new Base[]{
																								new NormalLoop(' ',null,0,(char)VK.VK_LCONTROL,null),
																								new Normal('}',null,0,(char)VK.VK_LCONTROL,null),
																								new Normal('.',null,0,' ',new Base[]{
																									new Normal('C',null,0,' ',new Base[]{
																										new Normal('O',null,0,' ',new Base[]{
																											new Normal('M',null,0,' ',new Base[]{
																												new Normal('B',null,0,' ',new Base[]{
																													new Normal('I',null,0,' ',new Base[]{
																														new CombinationLoop(' ',null,0,(char)VK.VK_LCONTROL,null),
																														new Combination('}',null,0,(char)VK.VK_LCONTROL,null),
																														new Normal(null,ParseException,0,' ',null)
																													}),
																													new Normal(null,ParseException,0,' ',null)
																												}),
																												new Normal(null,ParseException,0,' ',null)
																											}),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal('E',null,0,' ',new Base[]{
																		new Normal('F',null,0,' ',new Base[]{
																			new Normal('T',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_LEFT,null),
																				new Normal('}',null,0,(char)VK.VK_LEFT,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_LEFT,null),
																										new Combination('}',null,0,(char)VK.VK_LEFT,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal('M',null,0,' ',new Base[]{
																		new Normal('E',null,0,' ',new Base[]{
																			new Normal('N',null,0,' ',new Base[]{
																				new Normal('U',null,0,' ',new Base[]{
																					new NormalLoop(' ',null,0,(char)VK.VK_LMENU,null),
																					new Normal('}',null,0,(char)VK.VK_LMENU,null),
																					new Normal('.',null,0,' ',new Base[]{
																						new Normal('C',null,0,' ',new Base[]{
																							new Normal('O',null,0,' ',new Base[]{
																								new Normal('M',null,0,' ',new Base[]{
																									new Normal('B',null,0,' ',new Base[]{
																										new Normal('I',null,0,' ',new Base[]{
																											new CombinationLoop(' ',null,0,(char)VK.VK_LMENU,null),
																											new Combination('}',null,0,(char)VK.VK_LMENU,null),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal('S',null,0,' ',new Base[]{
																		new Normal('H',null,0,' ',new Base[]{
																			new Normal('I',null,0,' ',new Base[]{
																				new Normal('F',null,0,' ',new Base[]{
																					new Normal('T',null,0,' ',new Base[]{
																						new NormalLoop(' ',null,0,(char)VK.VK_LSHIFT,null),
																						new Normal('}',null,0,(char)VK.VK_LSHIFT,null),
																						new Normal('.',null,0,' ',new Base[]{
																							new Normal('C',null,0,' ',new Base[]{
																								new Normal('O',null,0,' ',new Base[]{
																									new Normal('M',null,0,' ',new Base[]{
																										new Normal('B',null,0,' ',new Base[]{
																											new Normal('I',null,0,' ',new Base[]{
																												new CombinationLoop(' ',null,0,(char)VK.VK_LSHIFT,null),
																												new Combination('}',null,0,(char)VK.VK_LSHIFT,null),
																												new Normal(null,ParseException,0,' ',null)
																											}),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal('W',null,0,' ',new Base[]{
																		new Normal('I',null,0,' ',new Base[]{
																			new Normal('N',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_LWIN,null),
																				new Normal('}',null,0,(char)VK.VK_LWIN,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_LWIN,null),
																										new Combination('}',null,0,(char)VK.VK_LWIN,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal(null,ParseException,0,' ',null)
																}),
																new Normal('M',null,0,' ',new Base[]{
																	new NormalLoop(' ',null,0,(char)VK.VK_M,null),
																	new Normal('}',null,0,(char)VK.VK_M,null),
																	new Normal('.',null,0,' ',new Base[]{
																		new Normal('C',null,0,' ',new Base[]{
																			new Normal('O',null,0,' ',new Base[]{
																				new Normal('M',null,0,' ',new Base[]{
																					new Normal('B',null,0,' ',new Base[]{
																						new Normal('I',null,0,' ',new Base[]{
																							new CombinationLoop(' ',null,0,(char)VK.VK_M,null),
																							new Combination('}',null,0,(char)VK.VK_M,null),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal('B',null,0,' ',new Base[]{
																		new Normal('U',null,0,' ',new Base[]{
																			new Normal('T',null,0,' ',new Base[]{
																				new Normal('T',null,0,' ',new Base[]{
																					new Normal('O',null,0,' ',new Base[]{
																						new Normal('N',null,0,' ',new Base[]{
																							new NormalLoop(' ',null,0,(char)VK.VK_MBUTTON,null),
																							new Normal('}',null,0,(char)VK.VK_MBUTTON,null),
																							new Normal('.',null,0,' ',new Base[]{
																								new Normal('C',null,0,' ',new Base[]{
																									new Normal('O',null,0,' ',new Base[]{
																										new Normal('M',null,0,' ',new Base[]{
																											new Normal('B',null,0,' ',new Base[]{
																												new Normal('I',null,0,' ',new Base[]{
																													new CombinationLoop(' ',null,0,(char)VK.VK_MBUTTON,null),
																													new Combination('}',null,0,(char)VK.VK_MBUTTON,null),
																													new Normal(null,ParseException,0,' ',null)
																												}),
																												new Normal(null,ParseException,0,' ',null)
																											}),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal('E',null,0,' ',new Base[]{
																		new Normal('D',null,0,' ',new Base[]{
																			new Normal('I',null,0,' ',new Base[]{
																				new Normal('A',null,0,' ',new Base[]{
																					new Normal('_',null,0,' ',new Base[]{
																						new Normal('N',null,0,' ',new Base[]{
																							new Normal('E',null,0,' ',new Base[]{
																								new Normal('X',null,0,' ',new Base[]{
																									new Normal('T',null,0,' ',new Base[]{
																										new Normal('_',null,0,' ',new Base[]{
																											new Normal('T',null,0,' ',new Base[]{
																												new Normal('R',null,0,' ',new Base[]{
																													new Normal('A',null,0,' ',new Base[]{
																														new Normal('C',null,0,' ',new Base[]{
																															new Normal('K',null,0,' ',new Base[]{
																																new NormalLoop(' ',null,0,(char)VK.VK_MEDIA_NEXT_TRACK,null),
																																new Normal('}',null,0,(char)VK.VK_MEDIA_NEXT_TRACK,null),
																																new Normal('.',null,0,' ',new Base[]{
																																	new Normal('C',null,0,' ',new Base[]{
																																		new Normal('O',null,0,' ',new Base[]{
																																			new Normal('M',null,0,' ',new Base[]{
																																				new Normal('B',null,0,' ',new Base[]{
																																					new Normal('I',null,0,' ',new Base[]{
																																						new CombinationLoop(' ',null,0,(char)VK.VK_MEDIA_NEXT_TRACK,null),
																																						new Combination('}',null,0,(char)VK.VK_MEDIA_NEXT_TRACK,null),
																																						new Normal(null,ParseException,0,' ',null)
																																					}),
																																					new Normal(null,ParseException,0,' ',null)
																																				}),
																																				new Normal(null,ParseException,0,' ',null)
																																			}),
																																			new Normal(null,ParseException,0,' ',null)
																																		}),
																																		new Normal(null,ParseException,0,' ',null)
																																	}),
																																	new Normal(null,ParseException,0,' ',null)
																																}),
																																new Normal(null,ParseException,0,' ',null)
																															}),
																															new Normal(null,ParseException,0,' ',null)
																														}),
																														new Normal(null,ParseException,0,' ',null)
																													}),
																													new Normal(null,ParseException,0,' ',null)
																												}),
																												new Normal(null,ParseException,0,' ',null)
																											}),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal('P',null,0,' ',new Base[]{
																							new Normal('L',null,0,' ',new Base[]{
																								new Normal('A',null,0,' ',new Base[]{
																									new Normal('Y',null,0,' ',new Base[]{
																										new Normal('_',null,0,' ',new Base[]{
																											new Normal('P',null,0,' ',new Base[]{
																												new Normal('A',null,0,' ',new Base[]{
																													new Normal('U',null,0,' ',new Base[]{
																														new Normal('S',null,0,' ',new Base[]{
																															new Normal('E',null,0,' ',new Base[]{
																																new NormalLoop(' ',null,0,(char)VK.VK_MEDIA_PLAY_PAUSE,null),
																																new Normal('}',null,0,(char)VK.VK_MEDIA_PLAY_PAUSE,null),
																																new Normal('.',null,0,' ',new Base[]{
																																	new Normal('C',null,0,' ',new Base[]{
																																		new Normal('O',null,0,' ',new Base[]{
																																			new Normal('M',null,0,' ',new Base[]{
																																				new Normal('B',null,0,' ',new Base[]{
																																					new Normal('I',null,0,' ',new Base[]{
																																						new CombinationLoop(' ',null,0,(char)VK.VK_MEDIA_PLAY_PAUSE,null),
																																						new Combination('}',null,0,(char)VK.VK_MEDIA_PLAY_PAUSE,null),
																																						new Normal(null,ParseException,0,' ',null)
																																					}),
																																					new Normal(null,ParseException,0,' ',null)
																																				}),
																																				new Normal(null,ParseException,0,' ',null)
																																			}),
																																			new Normal(null,ParseException,0,' ',null)
																																		}),
																																		new Normal(null,ParseException,0,' ',null)
																																	}),
																																	new Normal(null,ParseException,0,' ',null)
																																}),
																																new Normal(null,ParseException,0,' ',null)
																															}),
																															new Normal(null,ParseException,0,' ',null)
																														}),
																														new Normal(null,ParseException,0,' ',null)
																													}),
																													new Normal(null,ParseException,0,' ',null)
																												}),
																												new Normal(null,ParseException,0,' ',null)
																											}),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal('R',null,0,' ',new Base[]{
																								new Normal('E',null,0,' ',new Base[]{
																									new Normal('V',null,0,' ',new Base[]{
																										new Normal('_',null,0,' ',new Base[]{
																											new Normal('T',null,0,' ',new Base[]{
																												new Normal('R',null,0,' ',new Base[]{
																													new Normal('A',null,0,' ',new Base[]{
																														new Normal('C',null,0,' ',new Base[]{
																															new Normal('K',null,0,' ',new Base[]{
																																new NormalLoop(' ',null,0,(char)VK.VK_MEDIA_PREV_TRACK,null),
																																new Normal('}',null,0,(char)VK.VK_MEDIA_PREV_TRACK,null),
																																new Normal('.',null,0,' ',new Base[]{
																																	new Normal('C',null,0,' ',new Base[]{
																																		new Normal('O',null,0,' ',new Base[]{
																																			new Normal('M',null,0,' ',new Base[]{
																																				new Normal('B',null,0,' ',new Base[]{
																																					new Normal('I',null,0,' ',new Base[]{
																																						new CombinationLoop(' ',null,0,(char)VK.VK_MEDIA_PREV_TRACK,null),
																																						new Combination('}',null,0,(char)VK.VK_MEDIA_PREV_TRACK,null),
																																						new Normal(null,ParseException,0,' ',null)
																																					}),
																																					new Normal(null,ParseException,0,' ',null)
																																				}),
																																				new Normal(null,ParseException,0,' ',null)
																																			}),
																																			new Normal(null,ParseException,0,' ',null)
																																		}),
																																		new Normal(null,ParseException,0,' ',null)
																																	}),
																																	new Normal(null,ParseException,0,' ',null)
																																}),
																																new Normal(null,ParseException,0,' ',null)
																															}),
																															new Normal(null,ParseException,0,' ',null)
																														}),
																														new Normal(null,ParseException,0,' ',null)
																													}),
																													new Normal(null,ParseException,0,' ',null)
																												}),
																												new Normal(null,ParseException,0,' ',null)
																											}),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal('S',null,0,' ',new Base[]{
																							new Normal('T',null,0,' ',new Base[]{
																								new Normal('O',null,0,' ',new Base[]{
																									new Normal('P',null,0,' ',new Base[]{
																										new NormalLoop(' ',null,0,(char)VK.VK_MEDIA_STOP,null),
																										new Normal('}',null,0,(char)VK.VK_MEDIA_STOP,null),
																										new Normal('.',null,0,' ',new Base[]{
																											new Normal('C',null,0,' ',new Base[]{
																												new Normal('O',null,0,' ',new Base[]{
																													new Normal('M',null,0,' ',new Base[]{
																														new Normal('B',null,0,' ',new Base[]{
																															new Normal('I',null,0,' ',new Base[]{
																																new CombinationLoop(' ',null,0,(char)VK.VK_MEDIA_STOP,null),
																																new Combination('}',null,0,(char)VK.VK_MEDIA_STOP,null),
																																new Normal(null,ParseException,0,' ',null)
																															}),
																															new Normal(null,ParseException,0,' ',null)
																														}),
																														new Normal(null,ParseException,0,' ',null)
																													}),
																													new Normal(null,ParseException,0,' ',null)
																												}),
																												new Normal(null,ParseException,0,' ',null)
																											}),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal('N',null,0,' ',new Base[]{
																			new Normal('U',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_MENU,null),
																				new Normal('}',null,0,(char)VK.VK_MENU,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_MENU,null),
																										new Combination('}',null,0,(char)VK.VK_MENU,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal('O',null,0,' ',new Base[]{
																		new Normal('D',null,0,' ',new Base[]{
																			new Normal('E',null,0,' ',new Base[]{
																				new Normal('C',null,0,' ',new Base[]{
																					new Normal('H',null,0,' ',new Base[]{
																						new Normal('A',null,0,' ',new Base[]{
																							new Normal('N',null,0,' ',new Base[]{
																								new Normal('G',null,0,' ',new Base[]{
																									new Normal('E',null,0,' ',new Base[]{
																										new NormalLoop(' ',null,0,(char)VK.VK_MODECHANGE,null),
																										new Normal('}',null,0,(char)VK.VK_MODECHANGE,null),
																										new Normal('.',null,0,' ',new Base[]{
																											new Normal('C',null,0,' ',new Base[]{
																												new Normal('O',null,0,' ',new Base[]{
																													new Normal('M',null,0,' ',new Base[]{
																														new Normal('B',null,0,' ',new Base[]{
																															new Normal('I',null,0,' ',new Base[]{
																																new CombinationLoop(' ',null,0,(char)VK.VK_MODECHANGE,null),
																																new Combination('}',null,0,(char)VK.VK_MODECHANGE,null),
																																new Normal(null,ParseException,0,' ',null)
																															}),
																															new Normal(null,ParseException,0,' ',null)
																														}),
																														new Normal(null,ParseException,0,' ',null)
																													}),
																													new Normal(null,ParseException,0,' ',null)
																												}),
																												new Normal(null,ParseException,0,' ',null)
																											}),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal('U',null,0,' ',new Base[]{
																		new Normal('L',null,0,' ',new Base[]{
																			new Normal('T',null,0,' ',new Base[]{
																				new Normal('I',null,0,' ',new Base[]{
																					new Normal('P',null,0,' ',new Base[]{
																						new Normal('L',null,0,' ',new Base[]{
																							new Normal('Y',null,0,' ',new Base[]{
																								new NormalLoop(' ',null,0,(char)VK.VK_MULTIPLY,null),
																								new Normal('}',null,0,(char)VK.VK_MULTIPLY,null),
																								new Normal('.',null,0,' ',new Base[]{
																									new Normal('C',null,0,' ',new Base[]{
																										new Normal('O',null,0,' ',new Base[]{
																											new Normal('M',null,0,' ',new Base[]{
																												new Normal('B',null,0,' ',new Base[]{
																													new Normal('I',null,0,' ',new Base[]{
																														new CombinationLoop(' ',null,0,(char)VK.VK_MULTIPLY,null),
																														new Combination('}',null,0,(char)VK.VK_MULTIPLY,null),
																														new Normal(null,ParseException,0,' ',null)
																													}),
																													new Normal(null,ParseException,0,' ',null)
																												}),
																												new Normal(null,ParseException,0,' ',null)
																											}),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal(null,ParseException,0,' ',null)
																}),
																new Normal('N',null,0,' ',new Base[]{
																	new NormalLoop(' ',null,0,(char)VK.VK_N,null),
																	new Normal('}',null,0,(char)VK.VK_N,null),
																	new Normal('.',null,0,' ',new Base[]{
																		new Normal('C',null,0,' ',new Base[]{
																			new Normal('O',null,0,' ',new Base[]{
																				new Normal('M',null,0,' ',new Base[]{
																					new Normal('B',null,0,' ',new Base[]{
																						new Normal('I',null,0,' ',new Base[]{
																							new CombinationLoop(' ',null,0,(char)VK.VK_N,null),
																							new Combination('}',null,0,(char)VK.VK_N,null),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal('E',null,0,' ',new Base[]{
																		new Normal('X',null,0,' ',new Base[]{
																			new Normal('T',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_NEXT,null),
																				new Normal('}',null,0,(char)VK.VK_NEXT,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_NEXT,null),
																										new Combination('}',null,0,(char)VK.VK_NEXT,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal('O',null,0,' ',new Base[]{
																		new Normal('N',null,0,' ',new Base[]{
																			new Normal('A',null,0,' ',new Base[]{
																				new Normal('M',null,0,' ',new Base[]{
																					new Normal('E',null,0,' ',new Base[]{
																						new NormalLoop(' ',null,0,(char)VK.VK_NONAME,null),
																						new Normal('}',null,0,(char)VK.VK_NONAME,null),
																						new Normal('.',null,0,' ',new Base[]{
																							new Normal('C',null,0,' ',new Base[]{
																								new Normal('O',null,0,' ',new Base[]{
																									new Normal('M',null,0,' ',new Base[]{
																										new Normal('B',null,0,' ',new Base[]{
																											new Normal('I',null,0,' ',new Base[]{
																												new CombinationLoop(' ',null,0,(char)VK.VK_NONAME,null),
																												new Combination('}',null,0,(char)VK.VK_NONAME,null),
																												new Normal(null,ParseException,0,' ',null)
																											}),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('C',null,0,' ',new Base[]{
																				new Normal('O',null,0,' ',new Base[]{
																					new Normal('N',null,0,' ',new Base[]{
																						new Normal('V',null,0,' ',new Base[]{
																							new Normal('E',null,0,' ',new Base[]{
																								new Normal('R',null,0,' ',new Base[]{
																									new Normal('T',null,0,' ',new Base[]{
																										new NormalLoop(' ',null,0,(char)VK.VK_NONCONVERT,null),
																										new Normal('}',null,0,(char)VK.VK_NONCONVERT,null),
																										new Normal('.',null,0,' ',new Base[]{
																											new Normal('C',null,0,' ',new Base[]{
																												new Normal('O',null,0,' ',new Base[]{
																													new Normal('M',null,0,' ',new Base[]{
																														new Normal('B',null,0,' ',new Base[]{
																															new Normal('I',null,0,' ',new Base[]{
																																new CombinationLoop(' ',null,0,(char)VK.VK_NONCONVERT,null),
																																new Combination('}',null,0,(char)VK.VK_NONCONVERT,null),
																																new Normal(null,ParseException,0,' ',null)
																															}),
																															new Normal(null,ParseException,0,' ',null)
																														}),
																														new Normal(null,ParseException,0,' ',null)
																													}),
																													new Normal(null,ParseException,0,' ',null)
																												}),
																												new Normal(null,ParseException,0,' ',null)
																											}),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal('U',null,0,' ',new Base[]{
																		new Normal('M',null,0,' ',new Base[]{
																			new Normal('L',null,0,' ',new Base[]{
																				new Normal('O',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('K',null,0,' ',new Base[]{
																							new NormalLoop(' ',null,0,(char)VK.VK_NUMLOCK,null),
																							new Normal('}',null,0,(char)VK.VK_NUMLOCK,null),
																							new Normal('.',null,0,' ',new Base[]{
																								new Normal('C',null,0,' ',new Base[]{
																									new Normal('O',null,0,' ',new Base[]{
																										new Normal('M',null,0,' ',new Base[]{
																											new Normal('B',null,0,' ',new Base[]{
																												new Normal('I',null,0,' ',new Base[]{
																													new CombinationLoop(' ',null,0,(char)VK.VK_NUMLOCK,null),
																													new Combination('}',null,0,(char)VK.VK_NUMLOCK,null),
																													new Normal(null,ParseException,0,' ',null)
																												}),
																												new Normal(null,ParseException,0,' ',null)
																											}),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('P',null,0,' ',new Base[]{
																				new Normal('A',null,0,' ',new Base[]{
																					new Normal('D',null,0,' ',new Base[]{
																						new Normal('0',null,0,' ',new Base[]{
																							new NormalLoop(' ',null,0,(char)VK.VK_NUMPAD0,null),
																							new Normal('}',null,0,(char)VK.VK_NUMPAD0,null),
																							new Normal('.',null,0,' ',new Base[]{
																								new Normal('C',null,0,' ',new Base[]{
																									new Normal('O',null,0,' ',new Base[]{
																										new Normal('M',null,0,' ',new Base[]{
																											new Normal('B',null,0,' ',new Base[]{
																												new Normal('I',null,0,' ',new Base[]{
																													new CombinationLoop(' ',null,0,(char)VK.VK_NUMPAD0,null),
																													new Combination('}',null,0,(char)VK.VK_NUMPAD0,null),
																													new Normal(null,ParseException,0,' ',null)
																												}),
																												new Normal(null,ParseException,0,' ',null)
																											}),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal('1',null,0,' ',new Base[]{
																							new NormalLoop(' ',null,0,(char)VK.VK_NUMPAD1,null),
																							new Normal('}',null,0,(char)VK.VK_NUMPAD1,null),
																							new Normal('.',null,0,' ',new Base[]{
																								new Normal('C',null,0,' ',new Base[]{
																									new Normal('O',null,0,' ',new Base[]{
																										new Normal('M',null,0,' ',new Base[]{
																											new Normal('B',null,0,' ',new Base[]{
																												new Normal('I',null,0,' ',new Base[]{
																													new CombinationLoop(' ',null,0,(char)VK.VK_NUMPAD1,null),
																													new Combination('}',null,0,(char)VK.VK_NUMPAD1,null),
																													new Normal(null,ParseException,0,' ',null)
																												}),
																												new Normal(null,ParseException,0,' ',null)
																											}),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal('2',null,0,' ',new Base[]{
																							new NormalLoop(' ',null,0,(char)VK.VK_NUMPAD2,null),
																							new Normal('}',null,0,(char)VK.VK_NUMPAD2,null),
																							new Normal('.',null,0,' ',new Base[]{
																								new Normal('C',null,0,' ',new Base[]{
																									new Normal('O',null,0,' ',new Base[]{
																										new Normal('M',null,0,' ',new Base[]{
																											new Normal('B',null,0,' ',new Base[]{
																												new Normal('I',null,0,' ',new Base[]{
																													new CombinationLoop(' ',null,0,(char)VK.VK_NUMPAD2,null),
																													new Combination('}',null,0,(char)VK.VK_NUMPAD2,null),
																													new Normal(null,ParseException,0,' ',null)
																												}),
																												new Normal(null,ParseException,0,' ',null)
																											}),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal('3',null,0,' ',new Base[]{
																							new NormalLoop(' ',null,0,(char)VK.VK_NUMPAD3,null),
																							new Normal('}',null,0,(char)VK.VK_NUMPAD3,null),
																							new Normal('.',null,0,' ',new Base[]{
																								new Normal('C',null,0,' ',new Base[]{
																									new Normal('O',null,0,' ',new Base[]{
																										new Normal('M',null,0,' ',new Base[]{
																											new Normal('B',null,0,' ',new Base[]{
																												new Normal('I',null,0,' ',new Base[]{
																													new CombinationLoop(' ',null,0,(char)VK.VK_NUMPAD3,null),
																													new Combination('}',null,0,(char)VK.VK_NUMPAD3,null),
																													new Normal(null,ParseException,0,' ',null)
																												}),
																												new Normal(null,ParseException,0,' ',null)
																											}),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal('4',null,0,' ',new Base[]{
																							new NormalLoop(' ',null,0,(char)VK.VK_NUMPAD4,null),
																							new Normal('}',null,0,(char)VK.VK_NUMPAD4,null),
																							new Normal('.',null,0,' ',new Base[]{
																								new Normal('C',null,0,' ',new Base[]{
																									new Normal('O',null,0,' ',new Base[]{
																										new Normal('M',null,0,' ',new Base[]{
																											new Normal('B',null,0,' ',new Base[]{
																												new Normal('I',null,0,' ',new Base[]{
																													new CombinationLoop(' ',null,0,(char)VK.VK_NUMPAD4,null),
																													new Combination('}',null,0,(char)VK.VK_NUMPAD4,null),
																													new Normal(null,ParseException,0,' ',null)
																												}),
																												new Normal(null,ParseException,0,' ',null)
																											}),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal('5',null,0,' ',new Base[]{
																							new NormalLoop(' ',null,0,(char)VK.VK_NUMPAD5,null),
																							new Normal('}',null,0,(char)VK.VK_NUMPAD5,null),
																							new Normal('.',null,0,' ',new Base[]{
																								new Normal('C',null,0,' ',new Base[]{
																									new Normal('O',null,0,' ',new Base[]{
																										new Normal('M',null,0,' ',new Base[]{
																											new Normal('B',null,0,' ',new Base[]{
																												new Normal('I',null,0,' ',new Base[]{
																													new CombinationLoop(' ',null,0,(char)VK.VK_NUMPAD5,null),
																													new Combination('}',null,0,(char)VK.VK_NUMPAD5,null),
																													new Normal(null,ParseException,0,' ',null)
																												}),
																												new Normal(null,ParseException,0,' ',null)
																											}),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal('6',null,0,' ',new Base[]{
																							new NormalLoop(' ',null,0,(char)VK.VK_NUMPAD6,null),
																							new Normal('}',null,0,(char)VK.VK_NUMPAD6,null),
																							new Normal('.',null,0,' ',new Base[]{
																								new Normal('C',null,0,' ',new Base[]{
																									new Normal('O',null,0,' ',new Base[]{
																										new Normal('M',null,0,' ',new Base[]{
																											new Normal('B',null,0,' ',new Base[]{
																												new Normal('I',null,0,' ',new Base[]{
																													new CombinationLoop(' ',null,0,(char)VK.VK_NUMPAD6,null),
																													new Combination('}',null,0,(char)VK.VK_NUMPAD6,null),
																													new Normal(null,ParseException,0,' ',null)
																												}),
																												new Normal(null,ParseException,0,' ',null)
																											}),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal('7',null,0,' ',new Base[]{
																							new NormalLoop(' ',null,0,(char)VK.VK_NUMPAD7,null),
																							new Normal('}',null,0,(char)VK.VK_NUMPAD7,null),
																							new Normal('.',null,0,' ',new Base[]{
																								new Normal('C',null,0,' ',new Base[]{
																									new Normal('O',null,0,' ',new Base[]{
																										new Normal('M',null,0,' ',new Base[]{
																											new Normal('B',null,0,' ',new Base[]{
																												new Normal('I',null,0,' ',new Base[]{
																													new CombinationLoop(' ',null,0,(char)VK.VK_NUMPAD7,null),
																													new Combination('}',null,0,(char)VK.VK_NUMPAD7,null),
																													new Normal(null,ParseException,0,' ',null)
																												}),
																												new Normal(null,ParseException,0,' ',null)
																											}),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal('8',null,0,' ',new Base[]{
																							new NormalLoop(' ',null,0,(char)VK.VK_NUMPAD8,null),
																							new Normal('}',null,0,(char)VK.VK_NUMPAD8,null),
																							new Normal('.',null,0,' ',new Base[]{
																								new Normal('C',null,0,' ',new Base[]{
																									new Normal('O',null,0,' ',new Base[]{
																										new Normal('M',null,0,' ',new Base[]{
																											new Normal('B',null,0,' ',new Base[]{
																												new Normal('I',null,0,' ',new Base[]{
																													new CombinationLoop(' ',null,0,(char)VK.VK_NUMPAD8,null),
																													new Combination('}',null,0,(char)VK.VK_NUMPAD8,null),
																													new Normal(null,ParseException,0,' ',null)
																												}),
																												new Normal(null,ParseException,0,' ',null)
																											}),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal('9',null,0,' ',new Base[]{
																							new NormalLoop(' ',null,0,(char)VK.VK_NUMPAD9,null),
																							new Normal('}',null,0,(char)VK.VK_NUMPAD9,null),
																							new Normal('.',null,0,' ',new Base[]{
																								new Normal('C',null,0,' ',new Base[]{
																									new Normal('O',null,0,' ',new Base[]{
																										new Normal('M',null,0,' ',new Base[]{
																											new Normal('B',null,0,' ',new Base[]{
																												new Normal('I',null,0,' ',new Base[]{
																													new CombinationLoop(' ',null,0,(char)VK.VK_NUMPAD9,null),
																													new Combination('}',null,0,(char)VK.VK_NUMPAD9,null),
																													new Normal(null,ParseException,0,' ',null)
																												}),
																												new Normal(null,ParseException,0,' ',null)
																											}),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal(null,ParseException,0,' ',null)
																}),
																new Normal('O',null,0,' ',new Base[]{
																	new NormalLoop(' ',null,0,(char)VK.VK_O,null),
																	new Normal('}',null,0,(char)VK.VK_O,null),
																	new Normal('.',null,0,' ',new Base[]{
																		new Normal('C',null,0,' ',new Base[]{
																			new Normal('O',null,0,' ',new Base[]{
																				new Normal('M',null,0,' ',new Base[]{
																					new Normal('B',null,0,' ',new Base[]{
																						new Normal('I',null,0,' ',new Base[]{
																							new CombinationLoop(' ',null,0,(char)VK.VK_O,null),
																							new Combination('}',null,0,(char)VK.VK_O,null),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal('E',null,0,' ',new Base[]{
																		new Normal('M',null,0,' ',new Base[]{
																			new Normal('_',null,0,' ',new Base[]{
																				new Normal('1',null,0,' ',new Base[]{
																					new NormalLoop(' ',null,0,(char)VK.VK_OEM_1,null),
																					new Normal('}',null,0,(char)VK.VK_OEM_1,null),
																					new Normal('.',null,0,' ',new Base[]{
																						new Normal('C',null,0,' ',new Base[]{
																							new Normal('O',null,0,' ',new Base[]{
																								new Normal('M',null,0,' ',new Base[]{
																									new Normal('B',null,0,' ',new Base[]{
																										new Normal('I',null,0,' ',new Base[]{
																											new CombinationLoop(' ',null,0,(char)VK.VK_OEM_1,null),
																											new Combination('}',null,0,(char)VK.VK_OEM_1,null),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal('0',null,0,' ',new Base[]{
																						new Normal('2',null,0,' ',new Base[]{
																							new NormalLoop(' ',null,0,(char)VK.VK_OEM_102,null),
																							new Normal('}',null,0,(char)VK.VK_OEM_102,null),
																							new Normal('.',null,0,' ',new Base[]{
																								new Normal('C',null,0,' ',new Base[]{
																									new Normal('O',null,0,' ',new Base[]{
																										new Normal('M',null,0,' ',new Base[]{
																											new Normal('B',null,0,' ',new Base[]{
																												new Normal('I',null,0,' ',new Base[]{
																													new CombinationLoop(' ',null,0,(char)VK.VK_OEM_102,null),
																													new Combination('}',null,0,(char)VK.VK_OEM_102,null),
																													new Normal(null,ParseException,0,' ',null)
																												}),
																												new Normal(null,ParseException,0,' ',null)
																											}),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal('2',null,0,' ',new Base[]{
																					new NormalLoop(' ',null,0,(char)VK.VK_OEM_2,null),
																					new Normal('}',null,0,(char)VK.VK_OEM_2,null),
																					new Normal('.',null,0,' ',new Base[]{
																						new Normal('C',null,0,' ',new Base[]{
																							new Normal('O',null,0,' ',new Base[]{
																								new Normal('M',null,0,' ',new Base[]{
																									new Normal('B',null,0,' ',new Base[]{
																										new Normal('I',null,0,' ',new Base[]{
																											new CombinationLoop(' ',null,0,(char)VK.VK_OEM_2,null),
																											new Combination('}',null,0,(char)VK.VK_OEM_2,null),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal('3',null,0,' ',new Base[]{
																					new NormalLoop(' ',null,0,(char)VK.VK_OEM_3,null),
																					new Normal('}',null,0,(char)VK.VK_OEM_3,null),
																					new Normal('.',null,0,' ',new Base[]{
																						new Normal('C',null,0,' ',new Base[]{
																							new Normal('O',null,0,' ',new Base[]{
																								new Normal('M',null,0,' ',new Base[]{
																									new Normal('B',null,0,' ',new Base[]{
																										new Normal('I',null,0,' ',new Base[]{
																											new CombinationLoop(' ',null,0,(char)VK.VK_OEM_3,null),
																											new Combination('}',null,0,(char)VK.VK_OEM_3,null),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal('4',null,0,' ',new Base[]{
																					new NormalLoop(' ',null,0,(char)VK.VK_OEM_4,null),
																					new Normal('}',null,0,(char)VK.VK_OEM_4,null),
																					new Normal('.',null,0,' ',new Base[]{
																						new Normal('C',null,0,' ',new Base[]{
																							new Normal('O',null,0,' ',new Base[]{
																								new Normal('M',null,0,' ',new Base[]{
																									new Normal('B',null,0,' ',new Base[]{
																										new Normal('I',null,0,' ',new Base[]{
																											new CombinationLoop(' ',null,0,(char)VK.VK_OEM_4,null),
																											new Combination('}',null,0,(char)VK.VK_OEM_4,null),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal('5',null,0,' ',new Base[]{
																					new NormalLoop(' ',null,0,(char)VK.VK_OEM_5,null),
																					new Normal('}',null,0,(char)VK.VK_OEM_5,null),
																					new Normal('.',null,0,' ',new Base[]{
																						new Normal('C',null,0,' ',new Base[]{
																							new Normal('O',null,0,' ',new Base[]{
																								new Normal('M',null,0,' ',new Base[]{
																									new Normal('B',null,0,' ',new Base[]{
																										new Normal('I',null,0,' ',new Base[]{
																											new CombinationLoop(' ',null,0,(char)VK.VK_OEM_5,null),
																											new Combination('}',null,0,(char)VK.VK_OEM_5,null),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal('6',null,0,' ',new Base[]{
																					new NormalLoop(' ',null,0,(char)VK.VK_OEM_6,null),
																					new Normal('}',null,0,(char)VK.VK_OEM_6,null),
																					new Normal('.',null,0,' ',new Base[]{
																						new Normal('C',null,0,' ',new Base[]{
																							new Normal('O',null,0,' ',new Base[]{
																								new Normal('M',null,0,' ',new Base[]{
																									new Normal('B',null,0,' ',new Base[]{
																										new Normal('I',null,0,' ',new Base[]{
																											new CombinationLoop(' ',null,0,(char)VK.VK_OEM_6,null),
																											new Combination('}',null,0,(char)VK.VK_OEM_6,null),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal('7',null,0,' ',new Base[]{
																					new NormalLoop(' ',null,0,(char)VK.VK_OEM_7,null),
																					new Normal('}',null,0,(char)VK.VK_OEM_7,null),
																					new Normal('.',null,0,' ',new Base[]{
																						new Normal('C',null,0,' ',new Base[]{
																							new Normal('O',null,0,' ',new Base[]{
																								new Normal('M',null,0,' ',new Base[]{
																									new Normal('B',null,0,' ',new Base[]{
																										new Normal('I',null,0,' ',new Base[]{
																											new CombinationLoop(' ',null,0,(char)VK.VK_OEM_7,null),
																											new Combination('}',null,0,(char)VK.VK_OEM_7,null),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal('8',null,0,' ',new Base[]{
																					new NormalLoop(' ',null,0,(char)VK.VK_OEM_8,null),
																					new Normal('}',null,0,(char)VK.VK_OEM_8,null),
																					new Normal('.',null,0,' ',new Base[]{
																						new Normal('C',null,0,' ',new Base[]{
																							new Normal('O',null,0,' ',new Base[]{
																								new Normal('M',null,0,' ',new Base[]{
																									new Normal('B',null,0,' ',new Base[]{
																										new Normal('I',null,0,' ',new Base[]{
																											new CombinationLoop(' ',null,0,(char)VK.VK_OEM_8,null),
																											new Combination('}',null,0,(char)VK.VK_OEM_8,null),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal('C',null,0,' ',new Base[]{
																					new Normal('L',null,0,' ',new Base[]{
																						new Normal('E',null,0,' ',new Base[]{
																							new Normal('A',null,0,' ',new Base[]{
																								new Normal('R',null,0,' ',new Base[]{
																									new NormalLoop(' ',null,0,(char)VK.VK_OEM_CLEAR,null),
																									new Normal('}',null,0,(char)VK.VK_OEM_CLEAR,null),
																									new Normal('.',null,0,' ',new Base[]{
																										new Normal('C',null,0,' ',new Base[]{
																											new Normal('O',null,0,' ',new Base[]{
																												new Normal('M',null,0,' ',new Base[]{
																													new Normal('B',null,0,' ',new Base[]{
																														new Normal('I',null,0,' ',new Base[]{
																															new CombinationLoop(' ',null,0,(char)VK.VK_OEM_CLEAR,null),
																															new Combination('}',null,0,(char)VK.VK_OEM_CLEAR,null),
																															new Normal(null,ParseException,0,' ',null)
																														}),
																														new Normal(null,ParseException,0,' ',null)
																													}),
																													new Normal(null,ParseException,0,' ',null)
																												}),
																												new Normal(null,ParseException,0,' ',null)
																											}),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal('O',null,0,' ',new Base[]{
																						new Normal('M',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('A',null,0,' ',new Base[]{
																									new NormalLoop(' ',null,0,(char)VK.VK_OEM_COMMA,null),
																									new Normal('}',null,0,(char)VK.VK_OEM_COMMA,null),
																									new Normal('.',null,0,' ',new Base[]{
																										new Normal('C',null,0,' ',new Base[]{
																											new Normal('O',null,0,' ',new Base[]{
																												new Normal('M',null,0,' ',new Base[]{
																													new Normal('B',null,0,' ',new Base[]{
																														new Normal('I',null,0,' ',new Base[]{
																															new CombinationLoop(' ',null,0,(char)VK.VK_OEM_COMMA,null),
																															new Combination('}',null,0,(char)VK.VK_OEM_COMMA,null),
																															new Normal(null,ParseException,0,' ',null)
																														}),
																														new Normal(null,ParseException,0,' ',null)
																													}),
																													new Normal(null,ParseException,0,' ',null)
																												}),
																												new Normal(null,ParseException,0,' ',null)
																											}),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal('M',null,0,' ',new Base[]{
																					new Normal('I',null,0,' ',new Base[]{
																						new Normal('N',null,0,' ',new Base[]{
																							new Normal('U',null,0,' ',new Base[]{
																								new Normal('S',null,0,' ',new Base[]{
																									new NormalLoop(' ',null,0,(char)VK.VK_OEM_MINUS,null),
																									new Normal('}',null,0,(char)VK.VK_OEM_MINUS,null),
																									new Normal('.',null,0,' ',new Base[]{
																										new Normal('C',null,0,' ',new Base[]{
																											new Normal('O',null,0,' ',new Base[]{
																												new Normal('M',null,0,' ',new Base[]{
																													new Normal('B',null,0,' ',new Base[]{
																														new Normal('I',null,0,' ',new Base[]{
																															new CombinationLoop(' ',null,0,(char)VK.VK_OEM_MINUS,null),
																															new Combination('}',null,0,(char)VK.VK_OEM_MINUS,null),
																															new Normal(null,ParseException,0,' ',null)
																														}),
																														new Normal(null,ParseException,0,' ',null)
																													}),
																													new Normal(null,ParseException,0,' ',null)
																												}),
																												new Normal(null,ParseException,0,' ',null)
																											}),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal('P',null,0,' ',new Base[]{
																					new Normal('E',null,0,' ',new Base[]{
																						new Normal('R',null,0,' ',new Base[]{
																							new Normal('I',null,0,' ',new Base[]{
																								new Normal('O',null,0,' ',new Base[]{
																									new Normal('D',null,0,' ',new Base[]{
																										new NormalLoop(' ',null,0,(char)VK.VK_OEM_PERIOD,null),
																										new Normal('}',null,0,(char)VK.VK_OEM_PERIOD,null),
																										new Normal('.',null,0,' ',new Base[]{
																											new Normal('C',null,0,' ',new Base[]{
																												new Normal('O',null,0,' ',new Base[]{
																													new Normal('M',null,0,' ',new Base[]{
																														new Normal('B',null,0,' ',new Base[]{
																															new Normal('I',null,0,' ',new Base[]{
																																new CombinationLoop(' ',null,0,(char)VK.VK_OEM_PERIOD,null),
																																new Combination('}',null,0,(char)VK.VK_OEM_PERIOD,null),
																																new Normal(null,ParseException,0,' ',null)
																															}),
																															new Normal(null,ParseException,0,' ',null)
																														}),
																														new Normal(null,ParseException,0,' ',null)
																													}),
																													new Normal(null,ParseException,0,' ',null)
																												}),
																												new Normal(null,ParseException,0,' ',null)
																											}),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal('L',null,0,' ',new Base[]{
																						new Normal('U',null,0,' ',new Base[]{
																							new Normal('S',null,0,' ',new Base[]{
																								new NormalLoop(' ',null,0,(char)VK.VK_OEM_PLUS,null),
																								new Normal('}',null,0,(char)VK.VK_OEM_PLUS,null),
																								new Normal('.',null,0,' ',new Base[]{
																									new Normal('C',null,0,' ',new Base[]{
																										new Normal('O',null,0,' ',new Base[]{
																											new Normal('M',null,0,' ',new Base[]{
																												new Normal('B',null,0,' ',new Base[]{
																													new Normal('I',null,0,' ',new Base[]{
																														new CombinationLoop(' ',null,0,(char)VK.VK_OEM_PLUS,null),
																														new Combination('}',null,0,(char)VK.VK_OEM_PLUS,null),
																														new Normal(null,ParseException,0,' ',null)
																													}),
																													new Normal(null,ParseException,0,' ',null)
																												}),
																												new Normal(null,ParseException,0,' ',null)
																											}),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal(null,ParseException,0,' ',null)
																}),
																new Normal('P',null,0,' ',new Base[]{
																	new NormalLoop(' ',null,0,(char)VK.VK_P,null),
																	new Normal('}',null,0,(char)VK.VK_P,null),
																	new Normal('.',null,0,' ',new Base[]{
																		new Normal('C',null,0,' ',new Base[]{
																			new Normal('O',null,0,' ',new Base[]{
																				new Normal('M',null,0,' ',new Base[]{
																					new Normal('B',null,0,' ',new Base[]{
																						new Normal('I',null,0,' ',new Base[]{
																							new CombinationLoop(' ',null,0,(char)VK.VK_P,null),
																							new Combination('}',null,0,(char)VK.VK_P,null),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal('A',null,0,' ',new Base[]{
																		new Normal('1',null,0,' ',new Base[]{
																			new NormalLoop(' ',null,0,(char)VK.VK_PA1,null),
																			new Normal('}',null,0,(char)VK.VK_PA1,null),
																			new Normal('.',null,0,' ',new Base[]{
																				new Normal('C',null,0,' ',new Base[]{
																					new Normal('O',null,0,' ',new Base[]{
																						new Normal('M',null,0,' ',new Base[]{
																							new Normal('B',null,0,' ',new Base[]{
																								new Normal('I',null,0,' ',new Base[]{
																									new CombinationLoop(' ',null,0,(char)VK.VK_PA1,null),
																									new Combination('}',null,0,(char)VK.VK_PA1,null),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal('C',null,0,' ',new Base[]{
																			new Normal('K',null,0,' ',new Base[]{
																				new Normal('E',null,0,' ',new Base[]{
																					new Normal('T',null,0,' ',new Base[]{
																						new NormalLoop(' ',null,0,(char)VK.VK_PACKET,null),
																						new Normal('}',null,0,(char)VK.VK_PACKET,null),
																						new Normal('.',null,0,' ',new Base[]{
																							new Normal('C',null,0,' ',new Base[]{
																								new Normal('O',null,0,' ',new Base[]{
																									new Normal('M',null,0,' ',new Base[]{
																										new Normal('B',null,0,' ',new Base[]{
																											new Normal('I',null,0,' ',new Base[]{
																												new CombinationLoop(' ',null,0,(char)VK.VK_PACKET,null),
																												new Combination('}',null,0,(char)VK.VK_PACKET,null),
																												new Normal(null,ParseException,0,' ',null)
																											}),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal('U',null,0,' ',new Base[]{
																			new Normal('S',null,0,' ',new Base[]{
																				new Normal('E',null,0,' ',new Base[]{
																					new NormalLoop(' ',null,0,(char)VK.VK_PAUSE,null),
																					new Normal('}',null,0,(char)VK.VK_PAUSE,null),
																					new Normal('.',null,0,' ',new Base[]{
																						new Normal('C',null,0,' ',new Base[]{
																							new Normal('O',null,0,' ',new Base[]{
																								new Normal('M',null,0,' ',new Base[]{
																									new Normal('B',null,0,' ',new Base[]{
																										new Normal('I',null,0,' ',new Base[]{
																											new CombinationLoop(' ',null,0,(char)VK.VK_PAUSE,null),
																											new Combination('}',null,0,(char)VK.VK_PAUSE,null),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal('L',null,0,' ',new Base[]{
																		new Normal('A',null,0,' ',new Base[]{
																			new Normal('Y',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_PLAY,null),
																				new Normal('}',null,0,(char)VK.VK_PLAY,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_PLAY,null),
																										new Combination('}',null,0,(char)VK.VK_PLAY,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal('R',null,0,' ',new Base[]{
																		new Normal('I',null,0,' ',new Base[]{
																			new Normal('N',null,0,' ',new Base[]{
																				new Normal('T',null,0,' ',new Base[]{
																					new NormalLoop(' ',null,0,(char)VK.VK_PRINT,null),
																					new Normal('}',null,0,(char)VK.VK_PRINT,null),
																					new Normal('.',null,0,' ',new Base[]{
																						new Normal('C',null,0,' ',new Base[]{
																							new Normal('O',null,0,' ',new Base[]{
																								new Normal('M',null,0,' ',new Base[]{
																									new Normal('B',null,0,' ',new Base[]{
																										new Normal('I',null,0,' ',new Base[]{
																											new CombinationLoop(' ',null,0,(char)VK.VK_PRINT,null),
																											new Combination('}',null,0,(char)VK.VK_PRINT,null),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal('O',null,0,' ',new Base[]{
																				new Normal('R',null,0,' ',new Base[]{
																					new NormalLoop(' ',null,0,(char)VK.VK_PRIOR,null),
																					new Normal('}',null,0,(char)VK.VK_PRIOR,null),
																					new Normal('.',null,0,' ',new Base[]{
																						new Normal('C',null,0,' ',new Base[]{
																							new Normal('O',null,0,' ',new Base[]{
																								new Normal('M',null,0,' ',new Base[]{
																									new Normal('B',null,0,' ',new Base[]{
																										new Normal('I',null,0,' ',new Base[]{
																											new CombinationLoop(' ',null,0,(char)VK.VK_PRIOR,null),
																											new Combination('}',null,0,(char)VK.VK_PRIOR,null),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal('O',null,0,' ',new Base[]{
																			new Normal('C',null,0,' ',new Base[]{
																				new Normal('E',null,0,' ',new Base[]{
																					new Normal('S',null,0,' ',new Base[]{
																						new Normal('S',null,0,' ',new Base[]{
																							new Normal('K',null,0,' ',new Base[]{
																								new Normal('E',null,0,' ',new Base[]{
																									new Normal('Y',null,0,' ',new Base[]{
																										new NormalLoop(' ',null,0,(char)VK.VK_PROCESSKEY,null),
																										new Normal('}',null,0,(char)VK.VK_PROCESSKEY,null),
																										new Normal('.',null,0,' ',new Base[]{
																											new Normal('C',null,0,' ',new Base[]{
																												new Normal('O',null,0,' ',new Base[]{
																													new Normal('M',null,0,' ',new Base[]{
																														new Normal('B',null,0,' ',new Base[]{
																															new Normal('I',null,0,' ',new Base[]{
																																new CombinationLoop(' ',null,0,(char)VK.VK_PROCESSKEY,null),
																																new Combination('}',null,0,(char)VK.VK_PROCESSKEY,null),
																																new Normal(null,ParseException,0,' ',null)
																															}),
																															new Normal(null,ParseException,0,' ',null)
																														}),
																														new Normal(null,ParseException,0,' ',null)
																													}),
																													new Normal(null,ParseException,0,' ',null)
																												}),
																												new Normal(null,ParseException,0,' ',null)
																											}),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal(null,ParseException,0,' ',null)
																}),
																new Normal('Q',null,0,' ',new Base[]{
																	new NormalLoop(' ',null,0,(char)VK.VK_Q,null),
																	new Normal('}',null,0,(char)VK.VK_Q,null),
																	new Normal('.',null,0,' ',new Base[]{
																		new Normal('C',null,0,' ',new Base[]{
																			new Normal('O',null,0,' ',new Base[]{
																				new Normal('M',null,0,' ',new Base[]{
																					new Normal('B',null,0,' ',new Base[]{
																						new Normal('I',null,0,' ',new Base[]{
																							new CombinationLoop(' ',null,0,(char)VK.VK_Q,null),
																							new Combination('}',null,0,(char)VK.VK_Q,null),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal(null,ParseException,0,' ',null)
																}),
																new Normal('R',null,0,' ',new Base[]{
																	new NormalLoop(' ',null,0,(char)VK.VK_R,null),
																	new Normal('}',null,0,(char)VK.VK_R,null),
																	new Normal('.',null,0,' ',new Base[]{
																		new Normal('C',null,0,' ',new Base[]{
																			new Normal('O',null,0,' ',new Base[]{
																				new Normal('M',null,0,' ',new Base[]{
																					new Normal('B',null,0,' ',new Base[]{
																						new Normal('I',null,0,' ',new Base[]{
																							new CombinationLoop(' ',null,0,(char)VK.VK_R,null),
																							new Combination('}',null,0,(char)VK.VK_R,null),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal('B',null,0,' ',new Base[]{
																		new Normal('U',null,0,' ',new Base[]{
																			new Normal('T',null,0,' ',new Base[]{
																				new Normal('T',null,0,' ',new Base[]{
																					new Normal('O',null,0,' ',new Base[]{
																						new Normal('N',null,0,' ',new Base[]{
																							new NormalLoop(' ',null,0,(char)VK.VK_RBUTTON,null),
																							new Normal('}',null,0,(char)VK.VK_RBUTTON,null),
																							new Normal('.',null,0,' ',new Base[]{
																								new Normal('C',null,0,' ',new Base[]{
																									new Normal('O',null,0,' ',new Base[]{
																										new Normal('M',null,0,' ',new Base[]{
																											new Normal('B',null,0,' ',new Base[]{
																												new Normal('I',null,0,' ',new Base[]{
																													new CombinationLoop(' ',null,0,(char)VK.VK_RBUTTON,null),
																													new Combination('}',null,0,(char)VK.VK_RBUTTON,null),
																													new Normal(null,ParseException,0,' ',null)
																												}),
																												new Normal(null,ParseException,0,' ',null)
																											}),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal('C',null,0,' ',new Base[]{
																		new Normal('O',null,0,' ',new Base[]{
																			new Normal('N',null,0,' ',new Base[]{
																				new Normal('T',null,0,' ',new Base[]{
																					new Normal('R',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('L',null,0,' ',new Base[]{
																								new NormalLoop(' ',null,0,(char)VK.VK_RCONTROL,null),
																								new Normal('}',null,0,(char)VK.VK_RCONTROL,null),
																								new Normal('.',null,0,' ',new Base[]{
																									new Normal('C',null,0,' ',new Base[]{
																										new Normal('O',null,0,' ',new Base[]{
																											new Normal('M',null,0,' ',new Base[]{
																												new Normal('B',null,0,' ',new Base[]{
																													new Normal('I',null,0,' ',new Base[]{
																														new CombinationLoop(' ',null,0,(char)VK.VK_RCONTROL,null),
																														new Combination('}',null,0,(char)VK.VK_RCONTROL,null),
																														new Normal(null,ParseException,0,' ',null)
																													}),
																													new Normal(null,ParseException,0,' ',null)
																												}),
																												new Normal(null,ParseException,0,' ',null)
																											}),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal('E',null,0,' ',new Base[]{
																		new Normal('T',null,0,' ',new Base[]{
																			new Normal('U',null,0,' ',new Base[]{
																				new Normal('R',null,0,' ',new Base[]{
																					new Normal('N',null,0,' ',new Base[]{
																						new NormalLoop(' ',null,0,(char)VK.VK_RETURN,null),
																						new Normal('}',null,0,(char)VK.VK_RETURN,null),
																						new Normal('.',null,0,' ',new Base[]{
																							new Normal('C',null,0,' ',new Base[]{
																								new Normal('O',null,0,' ',new Base[]{
																									new Normal('M',null,0,' ',new Base[]{
																										new Normal('B',null,0,' ',new Base[]{
																											new Normal('I',null,0,' ',new Base[]{
																												new CombinationLoop(' ',null,0,(char)VK.VK_RETURN,null),
																												new Combination('}',null,0,(char)VK.VK_RETURN,null),
																												new Normal(null,ParseException,0,' ',null)
																											}),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal('I',null,0,' ',new Base[]{
																		new Normal('G',null,0,' ',new Base[]{
																			new Normal('H',null,0,' ',new Base[]{
																				new Normal('T',null,0,' ',new Base[]{
																					new NormalLoop(' ',null,0,(char)VK.VK_RIGHT,null),
																					new Normal('}',null,0,(char)VK.VK_RIGHT,null),
																					new Normal('.',null,0,' ',new Base[]{
																						new Normal('C',null,0,' ',new Base[]{
																							new Normal('O',null,0,' ',new Base[]{
																								new Normal('M',null,0,' ',new Base[]{
																									new Normal('B',null,0,' ',new Base[]{
																										new Normal('I',null,0,' ',new Base[]{
																											new CombinationLoop(' ',null,0,(char)VK.VK_RIGHT,null),
																											new Combination('}',null,0,(char)VK.VK_RIGHT,null),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal('M',null,0,' ',new Base[]{
																		new Normal('E',null,0,' ',new Base[]{
																			new Normal('N',null,0,' ',new Base[]{
																				new Normal('U',null,0,' ',new Base[]{
																					new NormalLoop(' ',null,0,(char)VK.VK_RMENU,null),
																					new Normal('}',null,0,(char)VK.VK_RMENU,null),
																					new Normal('.',null,0,' ',new Base[]{
																						new Normal('C',null,0,' ',new Base[]{
																							new Normal('O',null,0,' ',new Base[]{
																								new Normal('M',null,0,' ',new Base[]{
																									new Normal('B',null,0,' ',new Base[]{
																										new Normal('I',null,0,' ',new Base[]{
																											new CombinationLoop(' ',null,0,(char)VK.VK_RMENU,null),
																											new Combination('}',null,0,(char)VK.VK_RMENU,null),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal('S',null,0,' ',new Base[]{
																		new Normal('H',null,0,' ',new Base[]{
																			new Normal('I',null,0,' ',new Base[]{
																				new Normal('F',null,0,' ',new Base[]{
																					new Normal('T',null,0,' ',new Base[]{
																						new NormalLoop(' ',null,0,(char)VK.VK_RSHIFT,null),
																						new Normal('}',null,0,(char)VK.VK_RSHIFT,null),
																						new Normal('.',null,0,' ',new Base[]{
																							new Normal('C',null,0,' ',new Base[]{
																								new Normal('O',null,0,' ',new Base[]{
																									new Normal('M',null,0,' ',new Base[]{
																										new Normal('B',null,0,' ',new Base[]{
																											new Normal('I',null,0,' ',new Base[]{
																												new CombinationLoop(' ',null,0,(char)VK.VK_RSHIFT,null),
																												new Combination('}',null,0,(char)VK.VK_RSHIFT,null),
																												new Normal(null,ParseException,0,' ',null)
																											}),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal('W',null,0,' ',new Base[]{
																		new Normal('I',null,0,' ',new Base[]{
																			new Normal('N',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_RWIN,null),
																				new Normal('}',null,0,(char)VK.VK_RWIN,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_RWIN,null),
																										new Combination('}',null,0,(char)VK.VK_RWIN,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal(null,ParseException,0,' ',null)
																}),
																new Normal('S',null,0,' ',new Base[]{
																	new NormalLoop(' ',null,0,(char)VK.VK_S,null),
																	new Normal('}',null,0,(char)VK.VK_S,null),
																	new Normal('.',null,0,' ',new Base[]{
																		new Normal('C',null,0,' ',new Base[]{
																			new Normal('O',null,0,' ',new Base[]{
																				new Normal('M',null,0,' ',new Base[]{
																					new Normal('B',null,0,' ',new Base[]{
																						new Normal('I',null,0,' ',new Base[]{
																							new CombinationLoop(' ',null,0,(char)VK.VK_S,null),
																							new Combination('}',null,0,(char)VK.VK_S,null),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal('C',null,0,' ',new Base[]{
																		new Normal('R',null,0,' ',new Base[]{
																			new Normal('O',null,0,' ',new Base[]{
																				new Normal('L',null,0,' ',new Base[]{
																					new Normal('L',null,0,' ',new Base[]{
																						new NormalLoop(' ',null,0,(char)VK.VK_SCROLL,null),
																						new Normal('}',null,0,(char)VK.VK_SCROLL,null),
																						new Normal('.',null,0,' ',new Base[]{
																							new Normal('C',null,0,' ',new Base[]{
																								new Normal('O',null,0,' ',new Base[]{
																									new Normal('M',null,0,' ',new Base[]{
																										new Normal('B',null,0,' ',new Base[]{
																											new Normal('I',null,0,' ',new Base[]{
																												new CombinationLoop(' ',null,0,(char)VK.VK_SCROLL,null),
																												new Combination('}',null,0,(char)VK.VK_SCROLL,null),
																												new Normal(null,ParseException,0,' ',null)
																											}),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal('E',null,0,' ',new Base[]{
																		new Normal('L',null,0,' ',new Base[]{
																			new Normal('E',null,0,' ',new Base[]{
																				new Normal('C',null,0,' ',new Base[]{
																					new Normal('T',null,0,' ',new Base[]{
																						new NormalLoop(' ',null,0,(char)VK.VK_SELECT,null),
																						new Normal('}',null,0,(char)VK.VK_SELECT,null),
																						new Normal('.',null,0,' ',new Base[]{
																							new Normal('C',null,0,' ',new Base[]{
																								new Normal('O',null,0,' ',new Base[]{
																									new Normal('M',null,0,' ',new Base[]{
																										new Normal('B',null,0,' ',new Base[]{
																											new Normal('I',null,0,' ',new Base[]{
																												new CombinationLoop(' ',null,0,(char)VK.VK_SELECT,null),
																												new Combination('}',null,0,(char)VK.VK_SELECT,null),
																												new Normal(null,ParseException,0,' ',null)
																											}),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal('P',null,0,' ',new Base[]{
																			new Normal('A',null,0,' ',new Base[]{
																				new Normal('R',null,0,' ',new Base[]{
																					new Normal('A',null,0,' ',new Base[]{
																						new Normal('T',null,0,' ',new Base[]{
																							new Normal('O',null,0,' ',new Base[]{
																								new Normal('R',null,0,' ',new Base[]{
																									new NormalLoop(' ',null,0,(char)VK.VK_SEPARATOR,null),
																									new Normal('}',null,0,(char)VK.VK_SEPARATOR,null),
																									new Normal('.',null,0,' ',new Base[]{
																										new Normal('C',null,0,' ',new Base[]{
																											new Normal('O',null,0,' ',new Base[]{
																												new Normal('M',null,0,' ',new Base[]{
																													new Normal('B',null,0,' ',new Base[]{
																														new Normal('I',null,0,' ',new Base[]{
																															new CombinationLoop(' ',null,0,(char)VK.VK_SEPARATOR,null),
																															new Combination('}',null,0,(char)VK.VK_SEPARATOR,null),
																															new Normal(null,ParseException,0,' ',null)
																														}),
																														new Normal(null,ParseException,0,' ',null)
																													}),
																													new Normal(null,ParseException,0,' ',null)
																												}),
																												new Normal(null,ParseException,0,' ',null)
																											}),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal('H',null,0,' ',new Base[]{
																		new Normal('I',null,0,' ',new Base[]{
																			new Normal('F',null,0,' ',new Base[]{
																				new Normal('T',null,0,' ',new Base[]{
																					new NormalLoop(' ',null,0,(char)VK.VK_SHIFT,null),
																					new Normal('}',null,0,(char)VK.VK_SHIFT,null),
																					new Normal('.',null,0,' ',new Base[]{
																						new Normal('C',null,0,' ',new Base[]{
																							new Normal('O',null,0,' ',new Base[]{
																								new Normal('M',null,0,' ',new Base[]{
																									new Normal('B',null,0,' ',new Base[]{
																										new Normal('I',null,0,' ',new Base[]{
																											new CombinationLoop(' ',null,0,(char)VK.VK_SHIFT,null),
																											new Combination('}',null,0,(char)VK.VK_SHIFT,null),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal('L',null,0,' ',new Base[]{
																		new Normal('E',null,0,' ',new Base[]{
																			new Normal('E',null,0,' ',new Base[]{
																				new Normal('P',null,0,' ',new Base[]{
																					new NormalLoop(' ',null,0,(char)VK.VK_SLEEP,null),
																					new Normal('}',null,0,(char)VK.VK_SLEEP,null),
																					new Normal('.',null,0,' ',new Base[]{
																						new Normal('C',null,0,' ',new Base[]{
																							new Normal('O',null,0,' ',new Base[]{
																								new Normal('M',null,0,' ',new Base[]{
																									new Normal('B',null,0,' ',new Base[]{
																										new Normal('I',null,0,' ',new Base[]{
																											new CombinationLoop(' ',null,0,(char)VK.VK_SLEEP,null),
																											new Combination('}',null,0,(char)VK.VK_SLEEP,null),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal('N',null,0,' ',new Base[]{
																		new Normal('A',null,0,' ',new Base[]{
																			new Normal('P',null,0,' ',new Base[]{
																				new Normal('S',null,0,' ',new Base[]{
																					new Normal('H',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('T',null,0,' ',new Base[]{
																								new NormalLoop(' ',null,0,(char)VK.VK_SNAPSHOT,null),
																								new Normal('}',null,0,(char)VK.VK_SNAPSHOT,null),
																								new Normal('.',null,0,' ',new Base[]{
																									new Normal('C',null,0,' ',new Base[]{
																										new Normal('O',null,0,' ',new Base[]{
																											new Normal('M',null,0,' ',new Base[]{
																												new Normal('B',null,0,' ',new Base[]{
																													new Normal('I',null,0,' ',new Base[]{
																														new CombinationLoop(' ',null,0,(char)VK.VK_SNAPSHOT,null),
																														new Combination('}',null,0,(char)VK.VK_SNAPSHOT,null),
																														new Normal(null,ParseException,0,' ',null)
																													}),
																													new Normal(null,ParseException,0,' ',null)
																												}),
																												new Normal(null,ParseException,0,' ',null)
																											}),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal('P',null,0,' ',new Base[]{
																		new Normal('A',null,0,' ',new Base[]{
																			new Normal('C',null,0,' ',new Base[]{
																				new Normal('E',null,0,' ',new Base[]{
																					new NormalLoop(' ',null,0,(char)VK.VK_SPACE,null),
																					new Normal('}',null,0,(char)VK.VK_SPACE,null),
																					new Normal('.',null,0,' ',new Base[]{
																						new Normal('C',null,0,' ',new Base[]{
																							new Normal('O',null,0,' ',new Base[]{
																								new Normal('M',null,0,' ',new Base[]{
																									new Normal('B',null,0,' ',new Base[]{
																										new Normal('I',null,0,' ',new Base[]{
																											new CombinationLoop(' ',null,0,(char)VK.VK_SPACE,null),
																											new Combination('}',null,0,(char)VK.VK_SPACE,null),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal('U',null,0,' ',new Base[]{
																		new Normal('B',null,0,' ',new Base[]{
																			new Normal('T',null,0,' ',new Base[]{
																				new Normal('R',null,0,' ',new Base[]{
																					new Normal('A',null,0,' ',new Base[]{
																						new Normal('C',null,0,' ',new Base[]{
																							new Normal('T',null,0,' ',new Base[]{
																								new NormalLoop(' ',null,0,(char)VK.VK_SUBTRACT,null),
																								new Normal('}',null,0,(char)VK.VK_SUBTRACT,null),
																								new Normal('.',null,0,' ',new Base[]{
																									new Normal('C',null,0,' ',new Base[]{
																										new Normal('O',null,0,' ',new Base[]{
																											new Normal('M',null,0,' ',new Base[]{
																												new Normal('B',null,0,' ',new Base[]{
																													new Normal('I',null,0,' ',new Base[]{
																														new CombinationLoop(' ',null,0,(char)VK.VK_SUBTRACT,null),
																														new Combination('}',null,0,(char)VK.VK_SUBTRACT,null),
																														new Normal(null,ParseException,0,' ',null)
																													}),
																													new Normal(null,ParseException,0,' ',null)
																												}),
																												new Normal(null,ParseException,0,' ',null)
																											}),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal(null,ParseException,0,' ',null)
																}),
																new Normal('T',null,0,' ',new Base[]{
																	new NormalLoop(' ',null,0,(char)VK.VK_T,null),
																	new Normal('}',null,0,(char)VK.VK_T,null),
																	new Normal('.',null,0,' ',new Base[]{
																		new Normal('C',null,0,' ',new Base[]{
																			new Normal('O',null,0,' ',new Base[]{
																				new Normal('M',null,0,' ',new Base[]{
																					new Normal('B',null,0,' ',new Base[]{
																						new Normal('I',null,0,' ',new Base[]{
																							new CombinationLoop(' ',null,0,(char)VK.VK_T,null),
																							new Combination('}',null,0,(char)VK.VK_T,null),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal('A',null,0,' ',new Base[]{
																		new Normal('B',null,0,' ',new Base[]{
																			new NormalLoop(' ',null,0,(char)VK.VK_TAB,null),
																			new Normal('}',null,0,(char)VK.VK_TAB,null),
																			new Normal('.',null,0,' ',new Base[]{
																				new Normal('C',null,0,' ',new Base[]{
																					new Normal('O',null,0,' ',new Base[]{
																						new Normal('M',null,0,' ',new Base[]{
																							new Normal('B',null,0,' ',new Base[]{
																								new Normal('I',null,0,' ',new Base[]{
																									new CombinationLoop(' ',null,0,(char)VK.VK_TAB,null),
																									new Combination('}',null,0,(char)VK.VK_TAB,null),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal(null,ParseException,0,' ',null)
																}),
																new Normal('U',null,0,' ',new Base[]{
																	new NormalLoop(' ',null,0,(char)VK.VK_U,null),
																	new Normal('}',null,0,(char)VK.VK_U,null),
																	new Normal('.',null,0,' ',new Base[]{
																		new Normal('C',null,0,' ',new Base[]{
																			new Normal('O',null,0,' ',new Base[]{
																				new Normal('M',null,0,' ',new Base[]{
																					new Normal('B',null,0,' ',new Base[]{
																						new Normal('I',null,0,' ',new Base[]{
																							new CombinationLoop(' ',null,0,(char)VK.VK_U,null),
																							new Combination('}',null,0,(char)VK.VK_U,null),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal('P',null,0,' ',new Base[]{
																		new NormalLoop(' ',null,0,(char)VK.VK_UP,null),
																		new Normal('}',null,0,(char)VK.VK_UP,null),
																		new Normal('.',null,0,' ',new Base[]{
																			new Normal('C',null,0,' ',new Base[]{
																				new Normal('O',null,0,' ',new Base[]{
																					new Normal('M',null,0,' ',new Base[]{
																						new Normal('B',null,0,' ',new Base[]{
																							new Normal('I',null,0,' ',new Base[]{
																								new CombinationLoop(' ',null,0,(char)VK.VK_UP,null),
																								new Combination('}',null,0,(char)VK.VK_UP,null),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal(null,ParseException,0,' ',null)
																}),
																new Normal('V',null,0,' ',new Base[]{
																	new NormalLoop(' ',null,0,(char)VK.VK_V,null),
																	new Normal('}',null,0,(char)VK.VK_V,null),
																	new Normal('.',null,0,' ',new Base[]{
																		new Normal('C',null,0,' ',new Base[]{
																			new Normal('O',null,0,' ',new Base[]{
																				new Normal('M',null,0,' ',new Base[]{
																					new Normal('B',null,0,' ',new Base[]{
																						new Normal('I',null,0,' ',new Base[]{
																							new CombinationLoop(' ',null,0,(char)VK.VK_V,null),
																							new Combination('}',null,0,(char)VK.VK_V,null),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal('O',null,0,' ',new Base[]{
																		new Normal('L',null,0,' ',new Base[]{
																			new Normal('U',null,0,' ',new Base[]{
																				new Normal('M',null,0,' ',new Base[]{
																					new Normal('E',null,0,' ',new Base[]{
																						new Normal('_',null,0,' ',new Base[]{
																							new Normal('D',null,0,' ',new Base[]{
																								new Normal('O',null,0,' ',new Base[]{
																									new Normal('W',null,0,' ',new Base[]{
																										new Normal('N',null,0,' ',new Base[]{
																											new NormalLoop(' ',null,0,(char)VK.VK_VOLUME_DOWN,null),
																											new Normal('}',null,0,(char)VK.VK_VOLUME_DOWN,null),
																											new Normal('.',null,0,' ',new Base[]{
																												new Normal('C',null,0,' ',new Base[]{
																													new Normal('O',null,0,' ',new Base[]{
																														new Normal('M',null,0,' ',new Base[]{
																															new Normal('B',null,0,' ',new Base[]{
																																new Normal('I',null,0,' ',new Base[]{
																																	new CombinationLoop(' ',null,0,(char)VK.VK_VOLUME_DOWN,null),
																																	new Combination('}',null,0,(char)VK.VK_VOLUME_DOWN,null),
																																	new Normal(null,ParseException,0,' ',null)
																																}),
																																new Normal(null,ParseException,0,' ',null)
																															}),
																															new Normal(null,ParseException,0,' ',null)
																														}),
																														new Normal(null,ParseException,0,' ',null)
																													}),
																													new Normal(null,ParseException,0,' ',null)
																												}),
																												new Normal(null,ParseException,0,' ',null)
																											}),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('U',null,0,' ',new Base[]{
																									new Normal('T',null,0,' ',new Base[]{
																										new Normal('E',null,0,' ',new Base[]{
																											new NormalLoop(' ',null,0,(char)VK.VK_VOLUME_MUTE,null),
																											new Normal('}',null,0,(char)VK.VK_VOLUME_MUTE,null),
																											new Normal('.',null,0,' ',new Base[]{
																												new Normal('C',null,0,' ',new Base[]{
																													new Normal('O',null,0,' ',new Base[]{
																														new Normal('M',null,0,' ',new Base[]{
																															new Normal('B',null,0,' ',new Base[]{
																																new Normal('I',null,0,' ',new Base[]{
																																	new CombinationLoop(' ',null,0,(char)VK.VK_VOLUME_MUTE,null),
																																	new Combination('}',null,0,(char)VK.VK_VOLUME_MUTE,null),
																																	new Normal(null,ParseException,0,' ',null)
																																}),
																																new Normal(null,ParseException,0,' ',null)
																															}),
																															new Normal(null,ParseException,0,' ',null)
																														}),
																														new Normal(null,ParseException,0,' ',null)
																													}),
																													new Normal(null,ParseException,0,' ',null)
																												}),
																												new Normal(null,ParseException,0,' ',null)
																											}),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal('U',null,0,' ',new Base[]{
																								new Normal('P',null,0,' ',new Base[]{
																									new NormalLoop(' ',null,0,(char)VK.VK_VOLUME_UP,null),
																									new Normal('}',null,0,(char)VK.VK_VOLUME_UP,null),
																									new Normal('.',null,0,' ',new Base[]{
																										new Normal('C',null,0,' ',new Base[]{
																											new Normal('O',null,0,' ',new Base[]{
																												new Normal('M',null,0,' ',new Base[]{
																													new Normal('B',null,0,' ',new Base[]{
																														new Normal('I',null,0,' ',new Base[]{
																															new CombinationLoop(' ',null,0,(char)VK.VK_VOLUME_UP,null),
																															new Combination('}',null,0,(char)VK.VK_VOLUME_UP,null),
																															new Normal(null,ParseException,0,' ',null)
																														}),
																														new Normal(null,ParseException,0,' ',null)
																													}),
																													new Normal(null,ParseException,0,' ',null)
																												}),
																												new Normal(null,ParseException,0,' ',null)
																											}),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal(null,ParseException,0,' ',null)
																}),
																new Normal('W',null,0,' ',new Base[]{
																	new NormalLoop(' ',null,0,(char)VK.VK_W,null),
																	new Normal('}',null,0,(char)VK.VK_W,null),
																	new Normal('.',null,0,' ',new Base[]{
																		new Normal('C',null,0,' ',new Base[]{
																			new Normal('O',null,0,' ',new Base[]{
																				new Normal('M',null,0,' ',new Base[]{
																					new Normal('B',null,0,' ',new Base[]{
																						new Normal('I',null,0,' ',new Base[]{
																							new CombinationLoop(' ',null,0,(char)VK.VK_W,null),
																							new Combination('}',null,0,(char)VK.VK_W,null),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal(null,ParseException,0,' ',null)
																}),
																new Normal('X',null,0,' ',new Base[]{
																	new NormalLoop(' ',null,0,(char)VK.VK_X,null),
																	new Normal('}',null,0,(char)VK.VK_X,null),
																	new Normal('.',null,0,' ',new Base[]{
																		new Normal('C',null,0,' ',new Base[]{
																			new Normal('O',null,0,' ',new Base[]{
																				new Normal('M',null,0,' ',new Base[]{
																					new Normal('B',null,0,' ',new Base[]{
																						new Normal('I',null,0,' ',new Base[]{
																							new CombinationLoop(' ',null,0,(char)VK.VK_X,null),
																							new Combination('}',null,0,(char)VK.VK_X,null),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal('B',null,0,' ',new Base[]{
																		new Normal('U',null,0,' ',new Base[]{
																			new Normal('T',null,0,' ',new Base[]{
																				new Normal('T',null,0,' ',new Base[]{
																					new Normal('O',null,0,' ',new Base[]{
																						new Normal('N',null,0,' ',new Base[]{
																							new Normal('1',null,0,' ',new Base[]{
																								new NormalLoop(' ',null,0,(char)VK.VK_XBUTTON1,null),
																								new Normal('}',null,0,(char)VK.VK_XBUTTON1,null),
																								new Normal('.',null,0,' ',new Base[]{
																									new Normal('C',null,0,' ',new Base[]{
																										new Normal('O',null,0,' ',new Base[]{
																											new Normal('M',null,0,' ',new Base[]{
																												new Normal('B',null,0,' ',new Base[]{
																													new Normal('I',null,0,' ',new Base[]{
																														new CombinationLoop(' ',null,0,(char)VK.VK_XBUTTON1,null),
																														new Combination('}',null,0,(char)VK.VK_XBUTTON1,null),
																														new Normal(null,ParseException,0,' ',null)
																													}),
																													new Normal(null,ParseException,0,' ',null)
																												}),
																												new Normal(null,ParseException,0,' ',null)
																											}),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal('2',null,0,' ',new Base[]{
																								new NormalLoop(' ',null,0,(char)VK.VK_XBUTTON2,null),
																								new Normal('}',null,0,(char)VK.VK_XBUTTON2,null),
																								new Normal('.',null,0,' ',new Base[]{
																									new Normal('C',null,0,' ',new Base[]{
																										new Normal('O',null,0,' ',new Base[]{
																											new Normal('M',null,0,' ',new Base[]{
																												new Normal('B',null,0,' ',new Base[]{
																													new Normal('I',null,0,' ',new Base[]{
																														new CombinationLoop(' ',null,0,(char)VK.VK_XBUTTON2,null),
																														new Combination('}',null,0,(char)VK.VK_XBUTTON2,null),
																														new Normal(null,ParseException,0,' ',null)
																													}),
																													new Normal(null,ParseException,0,' ',null)
																												}),
																												new Normal(null,ParseException,0,' ',null)
																											}),
																											new Normal(null,ParseException,0,' ',null)
																										}),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal(null,ParseException,0,' ',null)
																}),
																new Normal('Y',null,0,' ',new Base[]{
																	new NormalLoop(' ',null,0,(char)VK.VK_Y,null),
																	new Normal('}',null,0,(char)VK.VK_Y,null),
																	new Normal('.',null,0,' ',new Base[]{
																		new Normal('C',null,0,' ',new Base[]{
																			new Normal('O',null,0,' ',new Base[]{
																				new Normal('M',null,0,' ',new Base[]{
																					new Normal('B',null,0,' ',new Base[]{
																						new Normal('I',null,0,' ',new Base[]{
																							new CombinationLoop(' ',null,0,(char)VK.VK_Y,null),
																							new Combination('}',null,0,(char)VK.VK_Y,null),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal(null,ParseException,0,' ',null)
																}),
																new Normal('Z',null,0,' ',new Base[]{
																	new NormalLoop(' ',null,0,(char)VK.VK_Z,null),
																	new Normal('}',null,0,(char)VK.VK_Z,null),
																	new Normal('.',null,0,' ',new Base[]{
																		new Normal('C',null,0,' ',new Base[]{
																			new Normal('O',null,0,' ',new Base[]{
																				new Normal('M',null,0,' ',new Base[]{
																					new Normal('B',null,0,' ',new Base[]{
																						new Normal('I',null,0,' ',new Base[]{
																							new CombinationLoop(' ',null,0,(char)VK.VK_Z,null),
																							new Combination('}',null,0,(char)VK.VK_Z,null),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal('O',null,0,' ',new Base[]{
																		new Normal('O',null,0,' ',new Base[]{
																			new Normal('M',null,0,' ',new Base[]{
																				new NormalLoop(' ',null,0,(char)VK.VK_ZOOM,null),
																				new Normal('}',null,0,(char)VK.VK_ZOOM,null),
																				new Normal('.',null,0,' ',new Base[]{
																					new Normal('C',null,0,' ',new Base[]{
																						new Normal('O',null,0,' ',new Base[]{
																							new Normal('M',null,0,' ',new Base[]{
																								new Normal('B',null,0,' ',new Base[]{
																									new Normal('I',null,0,' ',new Base[]{
																										new CombinationLoop(' ',null,0,(char)VK.VK_ZOOM,null),
																										new Combination('}',null,0,(char)VK.VK_ZOOM,null),
																										new Normal(null,ParseException,0,' ',null)
																									}),
																									new Normal(null,ParseException,0,' ',null)
																								}),
																								new Normal(null,ParseException,0,' ',null)
																							}),
																							new Normal(null,ParseException,0,' ',null)
																						}),
																						new Normal(null,ParseException,0,' ',null)
																					}),
																					new Normal(null,ParseException,0,' ',null)
																				}),
																				new Normal(null,ParseException,0,' ',null)
																			}),
																			new Normal(null,ParseException,0,' ',null)
																		}),
																		new Normal(null,ParseException,0,' ',null)
																	}),
																	new Normal(null,ParseException,0,' ',null)
																}),
																new Normal(null,ParseException,0,' ',null)
															}),
															new Normal(null,ParseException,0,' ',null)
														}),
														new Normal(null,ParseException,0,' ',null)
													}),
													new Normal(null,ParseException,0,' ',null)
												}),
												new Normal(null,ParseException,0,' ',null)
											}),
											new Normal(null,ParseException,0,' ',null)
										}),
										new Normal(null,ParseException,0,' ',null)
									}),
									new Normal(null,ParseException,0,' ',null)
								}),
								new Normal(null,ParseException,0,' ',null)
							}),
							new Normal(null,ParseException,0,' ',null)
						}),
						new Normal(null,ParseException,0,' ',null)
					}),
					new NormalLoop(' ',null,KeyboardFlag.Unicode,'W',null),
					new Normal('}',null,KeyboardFlag.Unicode,'W',null),
					new Normal(null,ParseException,0,' ',null)
				}),
				new Normal(null,null,0,' ',new Base[]{
					new NormalLoop(' ',GetPreCharKeyCode,KeyboardFlag.Unicode,' ',null),
					new Normal('}',GetPreCharKeyCode,KeyboardFlag.Unicode,' ',null),
					new Normal(null,ParseException,0,' ',null)
				})
			}),
			new Normal('~',null,0,(char)VK.VK_RETURN,null),
			new Combination('+',null,0,(char)VK.VK_SHIFT,null),
			new Normal(null,null,KeyboardFlag.Unicode,' ',null)
		};

	}
}